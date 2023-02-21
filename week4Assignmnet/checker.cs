using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.VisualBasic;

namespace week4Assignmnet
{
    internal class checker
    {
       
        List<Int64> IDs = new List<Int64>();
        List<string> Titles = new List<string>();
      
       
        private string id;
        private string title;
        private string genres;

        public String validate(string line)
        {
         

            var ind = line.IndexOf('"');
            if (ind == -1)
            {
                var movie = line.Split(',');

                id = movie[0]; 
                title = movie[1]; 
                genres = movie[2].Replace("|", ", ");
              
            }
            else
            {
                 id = line.Substring(0, ind - 1);

                line = line.Substring(ind + 1);
                ind = line.IndexOf('"');

                title = line.Substring(0, ind);
                line = line.Substring(ind + 2);

                genres = line.Replace("|", ", ");

               
            }
            IDs.Add(Int64.Parse(id));
            Titles.Add(title);
          
           

            return $"ID: {id}\nTitle: {title}\nGenre:{genres}";
        }


        public Boolean IdContains(Int64 id)
        {
            if (IDs.Contains(id))
            {
                return true;
            }

            return false;
        }

        public Boolean TitleContains(string title)
        {
            if (Titles.Contains(title))
            {
                return true;
            }

            return false;

        }


        public string create(Int64 id,string title, String genres)

        {
            return $"ID: {id}\nTitle: {title}\nGenre:{genres}";

        }
    }

  
}
