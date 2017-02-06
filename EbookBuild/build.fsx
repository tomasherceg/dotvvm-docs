#r "System.Xml.Linq"

open System.Xml.Linq
open System

type MenuItem = {
    RouteName: string
    PageName: string
    ChildItems: MenuItem list
}

let loadXml fileName =
    let rec deserialize (xml:XElement) = {
        RouteName=xml.Attribute(XName.Get "RouteName").Value
        PageName=xml.Attribute(XName.Get "PageName").Value
        ChildItems=xml.Elements(XName.Get "DocPageMenuItem") |> Seq.map deserialize |> Seq.toList }
    XDocument.Load(uri=fileName).Root.Elements(XName.Get "DocPageMenuItem")
        |> Seq.map deserialize
        |> Seq.toList

let rec flatten prefix menuItems =
    Seq.collect (fun i -> Seq.append [{i with RouteName = prefix + i.RouteName}] (flatten (prefix + i.RouteName + "-") i.ChildItems)) menuItems

let getPandocInputFiles menuItems =
    let paths = menuItems |> Seq.map (fun x -> (x.RouteName + ".md")) |> Seq.filter IO.File.Exists |> Seq.map (sprintf "%A")
    String.Join (" ", paths)

let titleTxt version = sprintf """
                       ---
                       title: DotVVM Docs (%s)
                       author: RIGANTI
                       rights:  Creative Commons Non-Commercial Share Alike 3.0
                       language: en-US
                       ...
                       """ version

let epubPandoc = sprintf "pandoc -s -S -o %s.epub --table-of-contents --epub-stylesheet=epub-stylesheet.css --webtex %s"
let htmlPandoc = sprintf "pandoc -s -S -o %s.html --css=epub-stylesheet.css --webtex %s"
let pdfPandoc = sprintf "pandoc -s -S --table-of-contents --toc-depth 1 -H template.tex -f markdown-raw_tex  -V documentclass=report -o %s.pdf %s"

let getPandocScript menuItems outputName addTexTemplate =
    sprintf "pandoc -o \"%s\" %s"
        outputName
   
let runScript (script:string) =
    let pinfo = new Diagnostics.ProcessStartInfo("C:\\Windows\\System32\\bash.exe")
    pinfo.Arguments <- script
    pinfo.WorkingDirectory <- IO.Directory.GetCurrentDirectory()
    let proc = Diagnostics.Process.Start(pinfo)
    proc.WaitForExit()

let menu = 
    if (1 = 3) then fsi.CommandLineArgs.[0] else "../menu.xml"
    |> loadXml
let fileNames = getPandocInputFiles (flatten "../Pages/" menu);
let script = pdfPandoc "docs-epub" fileNames
printfn "%s" script
IO.File.WriteAllText("./script", "export GHCRTS=-V0 \n pwd \n" + script + "\n", Text.Encoding.ASCII)

runScript "script"
0
