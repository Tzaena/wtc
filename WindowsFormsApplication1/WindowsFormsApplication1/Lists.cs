using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApplication1.Pairings;

namespace WindowsFormsApplication1
{
    public partial class Lists : Form
    {
        //json contentant toutes les teams
        private dynamic teams;
        int currentTeam = 0;
        public Lists()
        {
            ControlBox = false;
            InitializeComponent();
            if (loadJson())
            {
                comboBoxArmies.Hide();
                int cpt = 0;
                foreach (var elt in teams)
                {
                    comboBoxTeams.Items.Add(new ComboboxItem { Text = elt.name, Value = cpt.ToString() });
                    cpt++;
                }
                comboBoxTeams.CausesValidation = true;
                comboBoxTeams.SelectedIndexChanged += onchangeTeam;
                comboBoxArmies.CausesValidation = true;
                comboBoxArmies.SelectedIndexChanged += onchangePlayer;
                this.listViewList1.View = View.Details;
                this.listViewList1.Columns.Add("Name");
                this.listViewList1.Columns[0].Width = this.listViewList1.Width -
                4;
                this.listViewList1.HeaderStyle = ColumnHeaderStyle.None;
                this.listViewList2.View = View.Details;
                this.listViewList2.Columns.Add("Name");
                this.listViewList2.Columns[0].Width = this.listViewList2.Width -
                4;
                this.listViewList2.HeaderStyle = ColumnHeaderStyle.None;
            }
        }

        /// <summary>
        /// charge le json dans teams
        /// </summary>
        private bool loadJson()
        {
            try
            {
                using (StreamReader r = new StreamReader("lists.json"))
                {
                    string json = r.ReadToEnd();
                    teams = JsonConvert.DeserializeObject(json);
                }
                labelError.Hide();
                return true;
            }
            catch
            {
                labelError.Show();
                return false;
            }
        }

        /// <summary>
        /// charge les joueurs d'une équipe
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void onchangeTeam(object o, object e)
        {
            ComboboxItem item = (ComboboxItem)comboBoxTeams.SelectedItem;
            var team = teams[int.Parse(item.Value)];
            int cpt = 0;
            comboBoxArmies.Items.Clear();
            foreach (var elt in team.players)
            {
                comboBoxArmies.Items.Add(new ComboboxItem { Text = elt.faction + " - " + elt.name, Value = cpt.ToString() });
                cpt++;
            }
            currentTeam = int.Parse(item.Value);
            comboBoxArmies.Show();
        }
        /// <summary>
        /// charge les listes d'un joueur
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void onchangePlayer(object o, object e)
        {
            ComboboxItem item = (ComboboxItem)comboBoxArmies.SelectedItem;
            var player = teams[currentTeam].players[int.Parse(item.Value)];
            labelPlayer.Text = player.faction + " - " + player.name;
            listViewList1.Items.Clear();
            if (player.list1.theme != null)
                listViewList1.Items.Add(player.list1.theme.ToString());
            bool first = true;
            foreach (var elt in player.list1.list)
            {
                listViewList1.Items.Add((first ? " *** " : " - ") + elt.ToString());
                if (first) first = false;
            }
            listViewList2.Items.Clear();
            if (player.list2.theme != null)
                listViewList2.Items.Add(player.list2.theme.ToString());
            first = true;
            foreach (var elt in player.list2.list)
            {
                listViewList2.Items.Add((first ? " *** " : " - ") + elt.ToString());
                if (first) first = false;
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
