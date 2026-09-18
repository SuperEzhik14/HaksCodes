using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutProgram
{
    class Repost
    {
        public Video video;
        public List<Like> likes = new List<Like>();
        public string title {  get; protected set; }
        public Repost(Video video)
        {
            this.video = video;
        }

        public void ChangeTitle(string title)
        {
            this.title = title;
        }
    }
}
