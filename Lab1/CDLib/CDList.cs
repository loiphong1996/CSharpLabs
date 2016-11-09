using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLib
{
    public class CDList : List<CD>
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
                base.Add(cd);
                return true;
            }
        }

        public CD Find(string id)
        {
            return Find(cd => cd.Id.Equals(id));
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
            if (Count > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < Count; i++)
                {
                    stringBuilder.AppendLine("\nCD[" +i+ "]:");
                    stringBuilder.Append(this[i]);
                }

                return stringBuilder.ToString();
            }
            else
            {
                return "No CD available to show!\n";
            }
        }

        public CDList SearchByAlbum(string album)
        {
            var cdEnum = 
                from cd in this
                where cd.Album.ToUpper().Contains(album.ToUpper())
                select cd;
            
            CDList cdList = new CDList();
            cdList.AddRange(cdEnum);
            return cdList;
        }
        public CDList SearchBySinger(string singer)
        {
            var cdEnum = 
                from cd in this
                where cd.Singer.ToUpper().Contains(singer.ToUpper())
                select cd;

            CDList cdList = new CDList();
            cdList.AddRange(cdEnum);
            return cdList;
        }
        public CDList SearchBySong(string song)
        {
            var cdEnum = 
                from cd in this
                where cd.SongList.Exists(s => s.ToUpper().Contains(song.ToUpper()))
                select cd;

            CDList cdList = new CDList();
            cdList.AddRange(cdEnum);
            return cdList;
        }
    }
}
