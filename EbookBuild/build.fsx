#r "System.Xml.Linq"

open System.Xml.Linq
open System
open System.Text.RegularExpressions

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
    menuItems |> Seq.map (fun x -> (x.RouteName + ".md")) |> Seq.filter IO.File.Exists

let titleTxt version = sprintf """
                       ---
                       title: DotVVM Docs (%s)
                       author: RIGANTI
                       rights:  Creative Commons Non-Commercial Share Alike 3.0
                       language: en-US
                       ...
                       """ version

let epubPandoc = sprintf "pandoc -s -o %s.epub -f markdown --smart --table-of-contents --epub-stylesheet=epub-stylesheet.css --webtex %s"
let htmlPandoc = sprintf "pandoc -s -o %s.html -f markdown --smart --table-of-contents --css=epub-stylesheet.css --webtex %s"
let pdfPandoc = sprintf "pandoc -s --table-of-contents --toc-depth 1 -H template.tex -f markdown-raw_tex --smart  -V documentclass=report -o %s.pdf %s"

let replaceMarkdownFragments str =
    let imgReplacer (m:Match) = "![" + m.Groups.["alt"].Captures.[0].ToString() + "](../Pages/" + m.Groups.["src"].Captures.[0].ToString() + ")"
    Regex.Replace(str, "(<p>)?<img src=\"(\\{imageDir\\})?(?<src>.*)\"(\\W*alt=\"(?<alt>.*)\")\\W*\/>(<\/p>)?", imgReplacer)

let replaceLanguages str =
    Regex.Replace(Regex.Replace(str, "(?i)```\\W*dothtml", "``` html"), "(?i)```\\W*csharp", "``` cs")

let updateFile file =
    let result = IO.File.ReadAllText(file) |> replaceMarkdownFragments |> replaceLanguages
    IO.File.WriteAllText(file, result)

let getPandocScript menuItems outputName addTexTemplate =
    sprintf "pandoc -o \"%s\" %s"
        outputName
   
let runScript (script:string) =
    let pinfo = new Diagnostics.ProcessStartInfo("C:\\Windows\\System32\\bash.exe")
    pinfo.Arguments <- script
    pinfo.WorkingDirectory <- IO.Directory.GetCurrentDirectory()
    let proc = Diagnostics.Process.Start(pinfo)
    proc.WaitForExit()

let processScript fn name filePaths =
    let script = fn "dotvvm-docs-ebook" (String.Join(" ", filePaths |> Seq.map (sprintf "%A"))) 
    printfn "%s" script
    IO.File.WriteAllText(name, (* "export GHCRTS=-V0 \n pwd \n" +i *)  script + "\n", Text.Encoding.ASCII)
    //runScript name

let menu = 
    if (1 = 3) then fsi.CommandLineArgs.[0] else "../menu.xml"
    |> loadXml
let fileItems = flatten "../Pages/" menu |> Seq.toArray
let filePaths = getPandocInputFiles fileItems;
for f in filePaths do updateFile f

processScript pdfPandoc "./pdfScript" filePaths
processScript epubPandoc "./epubScript" filePaths
processScript htmlPandoc "./htmlScript" filePaths

// runScript "script"
0
