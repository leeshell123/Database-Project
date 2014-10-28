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
    public partial class _Default : Page
    {
        dbOperation dbop = new dbOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            dbOperation dbop = new dbOperation();
            
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox4.Text = dbop.getFilmInfo(TextBox1.Text); 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String name = TextBox5.Text;
            float score = float.Parse(TextBox19.Text);
            String result = dbop.rateFilm(name, score);
            //result = dbop.rateFilm(name, score);
            TextBox6.Text = result;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String director = TextBox7.Text;
            TextBox8.Text = dbop.findWithDirector(director);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            String actor = TextBox9.Text;
            TextBox10.Text = dbop.findWithActor(actor);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            String name = TextBox2.Text;
            String review = TextBox11.Text;
            TextBox3.Text = dbop.addReview(name, review);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String type = TextBox23.Text;
            TextBox24.Text = dbop.findWithType(type);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String name = TextBox12.Text;
            int year = int.Parse(TextBox13.Text);
            String actor = TextBox14.Text;
            String director = TextBox15.Text;
            String imdb_no = TextBox16.Text;
            float imdb_score = float.Parse(TextBox17.Text);
            String type = TextBox22.Text;
            String storyline = TextBox20.Text;
            String review = TextBox21.Text;

            TextBox18.Text = dbop.addFilm(name, year, actor, type, director, imdb_no, imdb_score, review, storyline);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            TextBox25.Text = dbop.orderByScore();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            String actor = TextBox26.Text;
            String director = TextBox27.Text;
            TextBox28.Text = dbop.findWithBoth(actor, director);
        }


       
    
    }
}