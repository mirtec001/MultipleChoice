using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultipleChoiceMVVM.Model
{

    public class DataModel
    {
        
        public List<List<string>> ConnectToDataBase(string datasource)
        {
            List<List<string>> data = new List<List<string>>();
            using (SQLiteConnection conn = new SQLiteConnection(@"DataSource=" + datasource))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("Select * from Questions", conn);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    var ndxPrimaryKey = reader.GetOrdinal("Index");
                    var ndxQuestion = reader.GetOrdinal("Question");
                    var ndxAnswer1 = reader.GetOrdinal("Answer1");
                    var ndxAnswer2 = reader.GetOrdinal("Answer2");
                    var ndxAnswer3 = reader.GetOrdinal("Answer3");
                    var ndxAnswer4 = reader.GetOrdinal("Answer4");

                    while (reader.Read())
                    {
                        List<string> record = new List<string>();
                        record.Add(reader.GetValue(ndxPrimaryKey) as string);
                        record.Add(reader.GetValue(ndxQuestion) as string);
                        record.Add(reader.GetValue(ndxAnswer1) as string);
                        record.Add(reader.GetValue(ndxAnswer2) as string);
                        record.Add(reader.GetValue(ndxAnswer3) as string);
                        record.Add(reader.GetValue(ndxAnswer4) as string);

                        data.Add(record);
                    }

                }

                conn.Close();

                // string message = data[0][1] + "\n" + data[0][2] + "\n" + data[0][3] + "\n" + data[0][4] + "\n" + data[0][5];
                // MessageBox.Show(message, "Question 0", MessageBoxButton.OK);
                return data;
            }
        }

        public void SaveQuestionsToDatabase(List<string> stream, string databasename)
        {
            

            for (int i = 0; i < stream.Count / 6; i += 6)
            {
                List<string> tempArray = new List<string>();
                // Array is laid out as 
                // [0] Question
                // [1] AnswerA
                // [2] AnswerB
                // [3] AnswerC
                // [4] AnswerD
                // [5] CorrectAnswer

                /*
                 * The table is laid out as 
                 * [0] primary key
                 * [1] Question
                 * [2] AnswerA (Correct Answer)
                 * [3] AnswerB
                 * [4] AnswerC
                 * [5] AnswerD
                 * 
                 * To get the two to mesh, we need to figure out the correct answer and put it in to slot 1 of our temp array
                 */

                tempArray.Add(stream[i + 0]);

                switch (stream[i + 5].ToLower())
                {
                    case "a":
                        tempArray.Add(stream[i + 1]);
                        tempArray.Add(stream[i + 2]);
                        tempArray.Add(stream[i + 3]);
                        tempArray.Add(stream[i + 4]);
                        break;
                    case "b":
                        tempArray.Add(stream[i + 2]);
                        tempArray.Add(stream[i + 3]);
                        tempArray.Add(stream[i + 4]);
                        tempArray.Add(stream[i + 1]);
                        break;
                    case "c":
                        tempArray.Add(stream[i + 3]);
                        tempArray.Add(stream[i + 4]);
                        tempArray.Add(stream[i + 1]);
                        tempArray.Add(stream[i + 2]);
                        break;
                    case "d":
                        tempArray.Add(stream[i + 4]);
                        tempArray.Add(stream[i + 1]);
                        tempArray.Add(stream[i + 2]);
                        tempArray.Add(stream[i + 3]);
                        break;
                }

                MessageBox.Show(tempArray[0] + "\n" + tempArray.Count.ToString(), "array contents", MessageBoxButton.OK);

                using (SQLiteConnection conn = new SQLiteConnection(@"DataSource=" + databasename))
                {
                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand("INSERT INTO questions(Question,Answer1,Answer2,Answer3,Answer4) VALUES(?,?,?,?,?)", conn);
                    command.Parameters.Add("@param1", System.Data.DbType.String).Value = tempArray[0];
                    command.Parameters.Add("@param2", System.Data.DbType.String).Value = tempArray[1];
                    command.Parameters.Add("@param3", System.Data.DbType.String).Value = tempArray[2];
                    command.Parameters.Add("@param4", System.Data.DbType.String).Value = tempArray[3];
                    command.Parameters.Add("@param5", System.Data.DbType.String).Value = tempArray[4];

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    conn.Close();
                }
            }
        }
    }
}
