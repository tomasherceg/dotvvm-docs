using System.Collections.Generic;
using System.Linq;

namespace Dotvvm.Samples.NavigationItem.sample1
{
    public class ViewModel
    {

        public int Likes { get; set; }

        public void Increment()
        {
            Likes++;
        }            
    }
}