using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Model
{
    public class Cell
    {
        public int value { get; set; }
        public bool dirty { get; set; }


        public Cell(int value)
        {
            this.value = value;
            this.dirty = false;

        }

        public bool IsEmpty()
        {
            return this.value == 0;

        }

        public void Clear()
        {
            this.dirty = false;
        }

        public static Cell operator +(Cell c1, Cell c2)
        {                       
            return new Cell(c1.value + c2.value);
        }

        public void makeEmpty()
        {
            this.value = 0;
        }



        public static bool operator ==(Cell c1, Cell c2)
        {
            return c1.value == c2.value;
        }

        public static bool operator !=(Cell c1, Cell c2)
        {
            return !(c1 == c2);
        }

        public string ToString()
        {
            return value.ToString();
        }

    }
}
