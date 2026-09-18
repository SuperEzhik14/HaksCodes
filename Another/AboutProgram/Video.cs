using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutProgram
{
    internal class Video
    {
        public DateTime date { get; } = DateTime.Now;
        public List<Like> likes = new List<Like>();
        public List<Comment> comments = new List<Comment>();
        public long views {  get; protected set; }
        public string Name { get; protected set; }
        public Video(string name)
        {
            Name = name;
        }
    }
}
