using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace Schiduch
{
    class Notes
    {
        public int NoteId;
        public string Note;
        public int Chadchan;
        public int Reason;

        public static Notes ReadNotesById(int ID)
        {
            Notes note = new Notes();
            try
            {
                string sql = "select * from notes where NOTEID=" + ID;

                SqlDataReader reader = DBFunction.ExecuteReader(sql);
                if (reader.Read())
                {
                    note.Note = (string)reader["notes"];
                    note.NoteId = (int)reader["noteid"];
                    note.Chadchan = (int)reader["Chadchan"];
                    note.Reason = (int)reader["reason"];
                    reader.Close();
                    return note;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
