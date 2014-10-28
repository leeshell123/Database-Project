using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Npgsql;

using MongoDB;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver.Wrappers;

namespace WebApplication2
{
    public class dbOperation
    {
   
        public dbOperation()
        {
            //this.dbinitial();
        }

        public void dbinitial()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");
            films.Drop();
            BsonDocument film1 = new BsonDocument {
                { "IMDB No", "tt0450345" },
                { "Type", new BsonArray(){"Horror", "Thriller", "Mystery"}},
                { "Actor", new BsonArray(){"Nicolas Cage", "Kate Beahan"} },
                { "Director", "John Polson" },
                {"Review", new BsonArray(){"OK, so I am an original Wicker Man fan and I usually don't like British films remade by Americans, so why oh why did I put myself through the most painful cinema experiences ever?"}},
                {"Storyline", "While recovering from a tragic accident on the road, the patrolman Edward Malus receives a letter from his former fiancée Willow, who left him years ago"}
            };

            BsonDocument film2 = new BsonDocument {
                { "IMDB No", "tt1250777" },
                { "Type", new BsonArray(){"Action", "Comedy"}},
                { "Actor", new BsonArray(){"Aaron Taylor-Johnson", "Nicolas Cage"} },
                { "Director", "Matthew Vaughn" },
                {"Review", new BsonArray(){"When I first saw Kick Ass i was expecting more action than comedy."}},
                {"Storyline", "Dave Lizewski is an unnoticed high school student and comic book fan with a few friends and who lives alone with his father."}
            };
            BsonDocument film3 = new BsonDocument {
                { "IMDB No", "tt0268978" },
                { "Type", new BsonArray(){"Biography", "Drama"}},
                { "Actor", new BsonArray(){"Russell Crowe", "Ed Harris"} },
                { "Director", "Ron Howard" },
                {"Review", new BsonArray(){"As the film unfolds the truly unremarkable, mathematical genius John Nash's life."}},
                {"Storyline", "A biopic of the meteoric rise of John Forbes Nash Jr., a math prodigy able to solve problems that baffled the greatest of minds."}
            };

            BsonDocument film4 = new BsonDocument {
                { "IMDB No", "tt0382077" },
                { "Type", new BsonArray(){"Horror", "Thriller", "Mystery"}},
                { "Actor", new BsonArray(){"Robert De Niro", "Dakota Fanning"} },
                { "Director", "John Polson" },
                {"Review", new BsonArray(){"All's not well at the home of the Callaways. David (Robert De Niro) and Alison (Amy Irving) have obvious tension in their relationship."}},
                {"Storyline", "Hide and Seek revolves around a widower and his daughter."}
            };

            BsonDocument film5 = new BsonDocument {
                { "IMDB No", "tt0810913" },
                { "Type", new BsonArray(){"Comedy"}},
                { "Actor", new BsonArray(){"Adam Sandler", "Katie Holmes"} },
                { "Director", "Dennis Dugan" },
                {"Review", new BsonArray(){"First Im a big Adam Sandler and of course I like Al but this is the worst movie I've seen since Howard The Duck!!!"}},
                {"Storyline", "Jack Sadelstein is a successful advertising executive in Los Angeles with a beautiful wife and kids, who dreads one event each year: the Thanksgiving visit of his identical twin sister Jill."}
            };

            BsonDocument film6 = new BsonDocument {
                { "IMDB No", "tt1375670" },
                { "Type", new BsonArray(){"Comedy"}},
                { "Actor", new BsonArray(){"Adam Sandler", "Fred Wolf"} },
                { "Director", "Dennis Dugan" },
                {"Review", new BsonArray(){"Humor just was awful. Its a movie for young kids and that's it. If you bring your eight year old s they may get a chuckle but that's it."}},
                {"Storyline", "In 1978, five 12-year-olds win a CYO basketball championship. Thirty years later, they gather with their families for their coach's funeral and a weekend at a house on a lake where they used to party."}
            };
            films.Insert(film1);
            films.Insert(film2);
            films.Insert(film3);
            films.Insert(film4);
            films.Insert(film5);
            films.Insert(film6);

            NpgsqlCommand truncateTable = new NpgsqlCommand("TRUNCATE TABLE film_info", conn);
            truncateTable.ExecuteNonQuery();
            NpgsqlCommand sqlfilm1 = new NpgsqlCommand("insert into film_info values('The Wicker Man', 'tt0450345', 3.6, 2006, 10)", conn);
            sqlfilm1.ExecuteNonQuery();
            NpgsqlCommand sqlfilm2 = new NpgsqlCommand("insert into film_info values('Kick-Ass', 'tt1250777', 7.8, 2010, 10)", conn);
            sqlfilm2.ExecuteNonQuery();
            NpgsqlCommand sqlfilm3 = new NpgsqlCommand("insert into film_info values('A Beautiful Mind', 'tt0268978', 8.2, 2001, 10)", conn);
            sqlfilm3.ExecuteNonQuery();
            NpgsqlCommand sqlfilm4 = new NpgsqlCommand("insert into film_info values('Hide and Seek', 'tt0382077', 5.9, 2005, 10)", conn);
            sqlfilm4.ExecuteNonQuery();
            NpgsqlCommand sqlfilm5 = new NpgsqlCommand("insert into film_info values('Jack and Jill', 'tt0810913', 3.5, 2011, 10)", conn);
            sqlfilm5.ExecuteNonQuery();
            NpgsqlCommand sqlfilm6 = new NpgsqlCommand("insert into film_info values('Grown Ups', 'tt1375670', 5.9, 2010, 10)", conn);
            sqlfilm6.ExecuteNonQuery();
            conn.Close();
        }

        public String addFilm(String name, int year, String actors, String type, String director, String imdb_no, float imdb_score, String review, String storyline)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");
            String result = null;
            var query = Query.EQ("IMDB No", imdb_no);
            BsonDocument film = films.FindOne(query);
            if (film != null)
            {
                result = "film already exist";
                conn.Close();
                return result;
            }

            String sql = "insert into film_info values('" + name + "', '" + imdb_no + "', " + imdb_score + ", " + year + ")";
            NpgsqlCommand sqlfilm1 = new NpgsqlCommand(sql, conn);
            sqlfilm1.ExecuteNonQuery();
            String[] types = type.Split(',');
            String[] Actors = actors.Split(',');
            BsonDocument newfilm = new BsonDocument {
                { "IMDB No", imdb_no },
                { "Type", new BsonArray(){types[0], types[1]}},
                { "Actor", new BsonArray(){Actors[0], Actors[1]} },
                { "Director", director },
                {"Review", new BsonArray(){review}},
                {"Storyline", storyline}
            };
            films.Insert(newfilm);

            result = getFilmInfo(name);
            conn.Close();
            return result;
 
        }

        public String addReview(String name, String review)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");
            String sql = "SELECT * FROM film_info WHERE name = '" + name + "'";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            String lstSelect = null;
            String result = null;
            if (dr.Read())
            {
                lstSelect += dr[1];
                dr.Close();
            }
            else
            {
                result = "film not exist";
                conn.Close();
                return result;
            }


            var query = Query.EQ("IMDB No", lstSelect);

            BsonDocument film = films.FindOne(query);
            if (film != null)
            {
                BsonValue re = (BsonValue)review;
                film["Review"].AsBsonArray.Add(re);
                films.Save(film);
            }
            result = getFilmInfo(name);
            conn.Close();
            return result;


        }

        public String findWithDirector(String director_name)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");
            String rs = null;
            
            var query = Query.EQ("Director", director_name);
            BsonDocument film = films.FindOne(query);
            if (film == null)
            {
                rs = "film not found";
                conn.Close();
                return rs;
            }
            foreach (BsonDocument result in films.Find(query))
            {
                // do something with book

                //string rc=result.ToJson<MongoDB.Bson.BsonDocument>();
                Hashtable rc = result.ToHashtable();
                String lstSelect = null;
                lstSelect += rc["IMDB No"];
                String sql = "SELECT * FROM film_info WHERE imdb_no = '" + lstSelect + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    rs += dr[0] + "\n";
                    dr.Close();
                }

                

            }
            conn.Close();
            return rs;
        }
        public String findWithBoth(String actor_name, String director_name)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");
            String rs = null;

            var query = Query.And(
                     Query.EQ("Actor", actor_name),
                     Query.EQ("Director", director_name)
                     );
            BsonDocument film = films.FindOne(query);
            if (film == null)
            {
                rs = "film not found";
                conn.Close();
                return rs;
            }
            foreach (BsonDocument result in films.Find(query))
            {
                // do something with book

                //string rc=result.ToJson<MongoDB.Bson.BsonDocument>();
                Hashtable rc = result.ToHashtable();
                String lstSelect = null;
                lstSelect += rc["IMDB No"];
                String sql = "SELECT * FROM film_info WHERE imdb_no = '" + lstSelect + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    rs += dr[0] + "\n";
                    dr.Close();
                }



            }
            conn.Close();
            return rs;
        }

        public String findWithType(String type)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");

            String rs = null;

            var query = Query.EQ("Type", type);
            BsonDocument film = films.FindOne(query);
            if (film == null)
            {
                rs = "film not found";
                conn.Close();
                return rs;
            }
            foreach (BsonDocument result in films.Find(query))
            {
                // do something with book

                //string rc=result.ToJson<MongoDB.Bson.BsonDocument>();
                Hashtable rc = result.ToHashtable();
                String lstSelect = null;
                lstSelect += rc["IMDB No"];
                String sql = "SELECT * FROM film_info WHERE imdb_no = '" + lstSelect + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    rs += dr[0] + "\n";
                    dr.Close();
                }
                

            }
            conn.Close();
            return rs;
        }

        public String findWithActor(String actor_name)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");
            String rs = null;
            
            var query = Query.EQ("Actor", actor_name);
            BsonDocument film = films.FindOne(query);
            if (film == null)
            {
                rs = "film not found";
                conn.Close();
                return rs;
            }
            foreach (BsonDocument result in films.Find(query))
            {
                // do something with book

                //string rc=result.ToJson<MongoDB.Bson.BsonDocument>();
                Hashtable rc = result.ToHashtable();
                String lstSelect = null;
                lstSelect += rc["IMDB No"];
                String sql = "SELECT * FROM film_info WHERE imdb_no = '" + lstSelect + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    rs += dr[0] + "\n";
                    dr.Close();
                }
                

            }
            conn.Close();
            return rs;
        }

        public String rateFilm(String film_name, float score)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();

            String lstSelect = null;

            String sql = "Update film_info Set imdb_score = (imdb_score*rated_time+" + score + ")/(rated_time+1), rated_time = rated_time+1 Where name = '" + film_name + "'";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "SELECT * FROM film_info WHERE name = '" + film_name + "'";
            command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                String fl = ((float)dr[2]).ToString("0.00");
                lstSelect = "Rate film sucessfully, The new score is " + fl + "\n";
            }
            else lstSelect = "film not found";
            dr.Close();
            conn.Close();
            return lstSelect;
        }

        public String getFilmInfo(String film_name)
        {
            NpgsqlConnection conn1 = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn1.Open();
            MongoClient client = new MongoClient(); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase film_info = server.GetDatabase("film_information");
            MongoCollection<BsonDocument> films = film_info.GetCollection<BsonDocument>("films");

            String lstSelect = null;

            String sql = "SELECT * FROM film_info WHERE name = '" + film_name + "'";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn1);
            NpgsqlDataReader dr = command.ExecuteReader();
            String imdb_no = null;
            //if (dr.Read() == false) lstSelect = "film not exist";
            if (dr.Read())
            {
                lstSelect = "Film Name: " + dr[0] + "\n";
                lstSelect = lstSelect + "IMDB NO: " + dr[1] + "\n";
                lstSelect = lstSelect + "IMDB SCORE: " + dr[2] + "\n";
                lstSelect = lstSelect + "IMDB Year: " + dr[3] + "\n";
                imdb_no += dr[1];
                dr.Close();
            }
            else 
            {
                lstSelect = "film not exist";
                conn1.Close();
                return lstSelect;
            }



            var query = Query.EQ("IMDB No", imdb_no);
            foreach (BsonDocument result in films.Find(query))
            {
                // do something with book

                //string rc=result.ToJson<MongoDB.Bson.BsonDocument>();
                Hashtable rc = result.ToHashtable();
                lstSelect = lstSelect + "Director: " + rc["Director"] + "\n";
                lstSelect = lstSelect + "Actor: ";
                object[] arr = (object[])rc["Actor"];
                foreach (object actor in arr)
                    lstSelect = lstSelect + actor + ",  ";
                lstSelect = lstSelect + "\n";

                lstSelect = lstSelect + "Type: ";
                arr = (object[])rc["Type"];
                foreach (object actor in arr)
                    lstSelect = lstSelect + actor + "  ";
                lstSelect = lstSelect + "\n";

                lstSelect = lstSelect + "Storyline: \n" + rc["Storyline"] + "\n\n\n";

                lstSelect = lstSelect + "Reviews: " + "\n";
                arr = (object[])rc["Review"];
                foreach (object actor in arr)
                    lstSelect = lstSelect + actor + "\n\n";
                lstSelect = lstSelect + "\n";


            }
            conn1.Close();
            return lstSelect;
        }

        public String orderByScore()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=3871;Database=film_information;");
            conn.Open();

            String lstSelect = null;

            String sql = "SELECT name, imdb_score FROM film_info ORDER BY imdb_score DESC";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
                lstSelect = lstSelect + dr[0] + "\t\t\t" + dr[1] + "\n";

            //dr.NextResult();

            //// Output the rows of the second result set
            //while (dr.Read())
            //    lstSelect = lstSelect + dr[0] + "\t" + dr[1] + "\n";

            dr.Close();
            
            conn.Close();
            return lstSelect;
        }
            

    }
}