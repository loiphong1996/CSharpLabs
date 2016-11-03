using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class CDList : List<CD>
    {
        public CDList()
        {
        }

        public new bool Add(CD cd)
        {
            if (Contains(cd))
            {
                return false;
            }
            else
            {
                Add(cd);
                return false;
            }
        }

        public CD Find(int id)
        {
            return Find(cd => cd.Id == id);
        }

        public void SortByAlbum(bool asc)
        {
            Comparison<CD> comparison;
            if (asc)
            {
                comparison = (cd, cd1) => cd.Album.CompareTo(cd1.Album);
            }
            else
            {
                comparison = (cd1, cd) => cd.Album.CompareTo(cd1.Album);
            }
            Sort(comparison);
        }
        public void SortBySinger(bool asc)
        {
            Comparison<CD> comparison;
            if (asc)
            {
                comparison = (cd, cd1) => cd.Singer.CompareTo(cd1.Singer);
            }
            else
            {
                comparison = (cd1, cd) => cd.Singer.CompareTo(cd1.Singer);
            }
            Sort(comparison);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append(this[i]);
            }

            return stringBuilder.ToString();
        }

        public List<CD> SearchByAlbum(string album)
        {
            var cdEnum = 
                from cd in this
                where cd.Album.Contains(album)
                select cd;
            
            return cdEnum.ToList();
        }
        public List<CD> SearchBySinger(string singer)
        {
            var cdEnum = 
                from cd in this
                where cd.Singer.Contains(singer)
                select cd;
            return cdEnum.ToList();
        }
        public List<CD> SearchBySong(string song)
        {
            var cdEnum = 
                from cd in this
                where cd.SongList.Exists(s => s.Contains(song))
                select cd;
            return cdEnum.ToList();
        }
    }
}
