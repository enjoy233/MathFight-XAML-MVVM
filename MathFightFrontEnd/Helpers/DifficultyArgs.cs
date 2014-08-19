using MathFightFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFightFrontEnd.Helpers
{
    public class DifficultyArgs : EventArgs
    {
        public Difficulty Difficulty { get; set; }

        public DifficultyArgs(Difficulty difficulty)
            : base()
        {
            this.Difficulty = difficulty;
        }
    }
}
