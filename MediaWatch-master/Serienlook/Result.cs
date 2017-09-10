using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serienlook
{
    class Result
    {


        public string resultName { get; set; }
        public int resultId { get; set; }
        public int resultVotes { get; set; }
        public float resultRating { get; set; }
        public string resultPosterPath { get; set; }
        public string resultDescription { get; set; }

        public Result(){
            this.resultName = "";
            this.resultId = 42;
            this.resultVotes = 42;
            this.resultRating = 42f;
            this.resultPosterPath = "/";
            this.resultDescription = "No Description available";
        }
    }
}
