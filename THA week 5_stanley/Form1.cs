using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static THA_week_5_stanley.Form1;

namespace THA_week_5_stanley
{
    public partial class Form1 : Form
    {
        public class Team
        {
            public string Teamname { get; set; }
            public string Teamcountry { get; set; }
            public string Teamcity { get; set; }
            public List<Player> Players = new List<Player>();

            public Team (string teamname, string teamcountry, string teamcity)
            {
                Teamname = teamname;
                Teamcountry = teamcountry;
                Teamcity = teamcity;
            }
        }

        public class Player
        {
            public string Playername { get; set; }
            public string Playernum { get; set; }
            public string Playerpos { get; set; }

            public Player(string playername, string playernum, string playerpos)
            {
                Playername = playername;
                Playernum = playernum;
                Playerpos = playerpos;
            }
        }

        List<Team> teams = new List<Team>();
        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Team barcelonaPlayers = new Team("FC Barcelona", "Spain", "Barcelona");
            barcelonaPlayers.Players.Add(new Player("Lionel Messi", " 10", " "));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));
            barcelonaPlayers.Players.Add(new Player("Marc-André ter Stegen", " 1", " Goalkeeper"));
            barcelonaPlayers.Players.Add(new Player("Ronald Araújo", " 4", " Centre-Back"));
            barcelonaPlayers.Players.Add(new Player("Andreas Christensen", " 15", " Centre-Back"));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));
            barcelonaPlayers.Players.Add(new Player("Gerard Pique", " 3", " Defender"));            
            teams.Add(barcelonaPlayers);

            Team realMadridPlayers = new Team("Real Madrid CF", "Spain", "Madrid");
            realMadridPlayers.Players.Add(new Player("Sergio Ramos", " 4", " Defender"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            realMadridPlayers.Players.Add(new Player("Karim Benzema", " 9", " Forward"));
            teams.Add(realMadridPlayers);

            Team manUtdPlayers = new Team("Manchester United", "England", "Manchester");           
            manUtdPlayers.Players.Add(new Player("Bruno Fernandes", " 18", " Midfielder"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));
            manUtdPlayers.Players.Add(new Player("Harry Maguire", " 5", " Defender"));     
            teams.Add(manUtdPlayers);

            comboBox1.Items.Add("Spain");
            comboBox1.Items.Add("England");
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Team team in teams)
                {
                    if (team.Teamcountry == comboBox1.Text)
                    {
                        comboBox2.Items.Add(team.Teamname);
                    }
                }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Team team in teams)
            {
              if(team.Teamname == comboBox2.Text)
              {
                 foreach(Player x in team.Players )
                 {
                     listBox1.Items.Add(x.Playername+x.Playernum+x.Playerpos);
                 }
              }
            }       
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addteam_btn_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            bool teamExists = false;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Team newteam = new Team(textBox1.Text, textBox2.Text, textBox3.Text);
                foreach (Team team in teams)
                {
                    if (team.Teamname == newteam.Teamname)
                    {
                        teamExists = true;
                    }
                }
                if (teamExists == false)
                {
                    teams.Add(newteam);
                }
                else
                {
                    MessageBox.Show("Team already exists, please add another team.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            foreach (Team team in teams)
            {
                if (!comboBox1.Items.Contains(team.Teamcountry))
                {
                   comboBox1.Items.Add(team.Teamcountry);
                }
            }
        }

        private void addplayer_btn_Click(object sender, EventArgs e)
        {
            bool tidakada = true;
            if (textBox4.Text == "" || textBox5.Text == "" || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Go ahead and fill in all the textboxes.");
            }
            else
            {
                if(comboBox2.Text == "")
                {
                    MessageBox.Show("Select a team first before proceeding.");
                }
                else
                {
                    Player newPlayer = new Player(textBox4.Text, textBox5.Text, comboBox3.Text);
                    foreach (Team z in teams)
                    {
                        if (z.Teamname == comboBox2.Text)
                        {

                            foreach (Player player in z.Players)
                            {
                                if (newPlayer.Playernum == player.Playernum)
                                {
                                    tidakada = false;
                                    break;
                                }
                            }
                            if (tidakada == true)
                            {
                                z.Players.Add(newPlayer);
                            }
                            else
                            {
                                MessageBox.Show("Player with same number already existed.");
                            }
                            break;
                        }
                    }
                }
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox3.SelectedIndex = -1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Team c in teams)
            {
                if (c.Teamname == comboBox2.SelectedItem.ToString())
                {
                    foreach(Player player in c.Players)
                    {
                        listBox1.Items.Add(player.Playername + player.Playernum + player.Playerpos);
                    }
                }
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
