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

namespace WindowsFormsApplication1
{
    public partial class Pairings : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        Lists lists = new Lists();

        public Pairings()
        {
            lists.Hide();
            InitializeComponent();
            var file = Directory.GetCurrentDirectory();
            //chargement des csv dans la combobox de teams
            var dirs = Directory.GetFiles(file, "*.csv");
            foreach (var f in dirs)
            {
                var name = f.Split('\\').Last().Replace(".csv", "");
                comboBoxTeams.Items.Add(new ComboboxItem { Text = name, Value = f });
            }
            comboBoxTeams.CausesValidation = true;
            comboBoxTeams.SelectedIndexChanged += onchange;
            //gestion de la couleur de fond des combobox de note
            comboBoxj1v1.SelectedIndexChanged += onchangenote;
            comboBoxj1v2.SelectedIndexChanged += onchangenote;
            comboBoxj1v3.SelectedIndexChanged += onchangenote;
            comboBoxj1v4.SelectedIndexChanged += onchangenote;
            comboBoxj1v5.SelectedIndexChanged += onchangenote;
            comboBoxj2v1.SelectedIndexChanged += onchangenote;
            comboBoxj2v2.SelectedIndexChanged += onchangenote;
            comboBoxj2v3.SelectedIndexChanged += onchangenote;
            comboBoxj2v4.SelectedIndexChanged += onchangenote;
            comboBoxj2v5.SelectedIndexChanged += onchangenote;
            comboBoxj3v1.SelectedIndexChanged += onchangenote;
            comboBoxj3v2.SelectedIndexChanged += onchangenote;
            comboBoxj3v3.SelectedIndexChanged += onchangenote;
            comboBoxj3v4.SelectedIndexChanged += onchangenote;
            comboBoxj3v5.SelectedIndexChanged += onchangenote;
            comboBoxj4v1.SelectedIndexChanged += onchangenote;
            comboBoxj4v2.SelectedIndexChanged += onchangenote;
            comboBoxj4v3.SelectedIndexChanged += onchangenote;
            comboBoxj4v4.SelectedIndexChanged += onchangenote;
            comboBoxj4v5.SelectedIndexChanged += onchangenote;
            comboBoxj5v1.SelectedIndexChanged += onchangenote;
            comboBoxj5v2.SelectedIndexChanged += onchangenote;
            comboBoxj5v3.SelectedIndexChanged += onchangenote;
            comboBoxj5v4.SelectedIndexChanged += onchangenote;
            comboBoxj5v5.SelectedIndexChanged += onchangenote;
            
        }
        /// <summary>
        /// change la couleur de la combobox courante
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void onchangenote(object o, object e)
        {
            ComboBox box = (ComboBox)o;
            switch (box.Text) 
            {
                case "1": box.BackColor = Color.LightBlue; break;
                case "2": box.BackColor = Color.LightGreen; break;
                case "3": box.BackColor = Color.LightYellow; break;
                case "4": box.BackColor = Color.Orange; break;
                case "5": box.BackColor = Color.Red; break;
            }
        }
        /// <summary>
        /// charge les infos de notes dans les combobox à partir d'un fichier
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void onchange(object o, object e)
        {
            ComboboxItem file = (ComboboxItem)comboBoxTeams.SelectedItem;
            var result = read(file.Value);
            textBoxa1.Text = result[0][0];
            textBoxa2.Text = result[0][1];
            textBoxa3.Text = result[0][2];
            textBoxa4.Text = result[0][3];
            textBoxa5.Text = result[0][4];
            textBoxj1.Text = result[1][0];
            comboBoxj1v1.SelectedIndex = int.Parse(result[1][1]) - 1;
            comboBoxj1v2.SelectedIndex = int.Parse(result[1][2]) - 1;
            comboBoxj1v3.SelectedIndex = int.Parse(result[1][3]) - 1;
            comboBoxj1v4.SelectedIndex = int.Parse(result[1][4]) - 1;
            comboBoxj1v5.SelectedIndex = int.Parse(result[1][5]) - 1;
            textBoxj2.Text = result[2][0];
            comboBoxj2v1.SelectedIndex = int.Parse(result[2][1]) - 1;
            comboBoxj2v2.SelectedIndex = int.Parse(result[2][2]) - 1;
            comboBoxj2v3.SelectedIndex = int.Parse(result[2][3]) - 1;
            comboBoxj2v4.SelectedIndex = int.Parse(result[2][4]) - 1;
            comboBoxj2v5.SelectedIndex = int.Parse(result[2][5]) - 1;
            textBoxj3.Text = result[3][0];
            comboBoxj3v1.SelectedIndex = int.Parse(result[3][1]) - 1;
            comboBoxj3v2.SelectedIndex = int.Parse(result[3][2]) - 1;
            comboBoxj3v3.SelectedIndex = int.Parse(result[3][3]) - 1;
            comboBoxj3v4.SelectedIndex = int.Parse(result[3][4]) - 1;
            comboBoxj3v5.SelectedIndex = int.Parse(result[3][5]) - 1;
            textBoxj4.Text = result[4][0];
            comboBoxj4v1.SelectedIndex = int.Parse(result[4][1]) - 1;
            comboBoxj4v2.SelectedIndex = int.Parse(result[4][2]) - 1;
            comboBoxj4v3.SelectedIndex = int.Parse(result[4][3]) - 1;
            comboBoxj4v4.SelectedIndex = int.Parse(result[4][4]) - 1;
            comboBoxj4v5.SelectedIndex = int.Parse(result[4][5]) - 1;
            textBoxj5.Text = result[5][0];
            comboBoxj5v1.SelectedIndex = int.Parse(result[5][1]) - 1;
            comboBoxj5v2.SelectedIndex = int.Parse(result[5][2]) - 1;
            comboBoxj5v3.SelectedIndex = int.Parse(result[5][3]) - 1;
            comboBoxj5v4.SelectedIndex = int.Parse(result[5][4]) - 1;
            comboBoxj5v5.SelectedIndex = int.Parse(result[5][5]) - 1;
        }
        /// <summary>
        /// charge les notes dans un tableau 2D à partir d'un fichier
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<List<string>> read(string file)
        {
            List<List<string>> liste = new List<List<string>>();
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = null;
                    if (line.Contains(";"))
                        values = line.Split(';');
                    else if (line.Contains(","))
                            values = line.Split(',');
                    var listeTmp = new List<string>();
                    if (values != null)
                    {
                        foreach (var val in values)
                        {
                            listeTmp.Add(val);
                        }
                    }
                    liste.Add(listeTmp);
                }
            }
            return liste;
        }

        /// <summary>
        /// enregistre les notes courantes dans un fichier csv lors du clic sur enregistrer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    string text = "";
                    text += textBoxa1.Text + ";" + textBoxa2.Text + ";" + textBoxa3.Text + ";" + textBoxa4.Text + ";" + textBoxa5.Text;
                    text += "\n" + textBoxj1.Text + ";" + comboBoxj1v1.SelectedItem.ToString() + ";" + comboBoxj1v2.SelectedItem.ToString() + ";" + comboBoxj1v3.SelectedItem.ToString()  + ";" + comboBoxj1v4.SelectedItem.ToString()  + ";" + comboBoxj1v5.SelectedItem.ToString();
                    text += "\n" + textBoxj2.Text + ";" + comboBoxj2v1.SelectedItem.ToString() + ";" + comboBoxj2v2.SelectedItem.ToString() + ";" + comboBoxj2v3.SelectedItem.ToString() + ";" + comboBoxj2v4.SelectedItem.ToString() + ";" + comboBoxj2v5.SelectedItem.ToString();
                    text += "\n" + textBoxj3.Text + ";" + comboBoxj3v1.SelectedItem.ToString() + ";" + comboBoxj3v2.SelectedItem.ToString() + ";" + comboBoxj3v3.SelectedItem.ToString() + ";" + comboBoxj3v4.SelectedItem.ToString() + ";" + comboBoxj3v5.SelectedItem.ToString();
                    text += "\n" + textBoxj4.Text + ";" + comboBoxj4v1.SelectedItem.ToString() + ";" + comboBoxj4v2.SelectedItem.ToString() + ";" + comboBoxj4v3.SelectedItem.ToString() + ";" + comboBoxj4v4.SelectedItem.ToString() + ";" + comboBoxj4v5.SelectedItem.ToString();
                    text += "\n" + textBoxj5.Text + ";" + comboBoxj5v1.SelectedItem.ToString() + ";" + comboBoxj5v2.SelectedItem.ToString() + ";" + comboBoxj5v3.SelectedItem.ToString() + ";" + comboBoxj5v4.SelectedItem.ToString() + ";" + comboBoxj5v5.SelectedItem.ToString();
                    Byte[] info = new UTF8Encoding(true).GetBytes(text);
                    myStream.Write(info, 0, info.Length);
                    myStream.Close();
                }
            }
        }

        /// <summary>
        /// Génère les appariements lors du clic sur générer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            results = new List<node>();
            //chargement des infos des joueurs renseignées dans le tableau
            List<int> j1 = new List<int> { int.Parse(comboBoxj1v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj1v2.SelectedItem.ToString()), int.Parse(comboBoxj1v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj1v4.SelectedItem.ToString()), int.Parse(comboBoxj1v5.SelectedItem.ToString()) };
            List<int> j2 = new List<int> { int.Parse(comboBoxj2v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v2.SelectedItem.ToString()), int.Parse(comboBoxj2v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v4.SelectedItem.ToString()), int.Parse(comboBoxj2v5.SelectedItem.ToString()) };
            List<int> j3 = new List<int> { int.Parse(comboBoxj3v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj3v2.SelectedItem.ToString()), int.Parse(comboBoxj3v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj3v4.SelectedItem.ToString()), int.Parse(comboBoxj3v5.SelectedItem.ToString()) };
            List<int> j4 = new List<int> { int.Parse(comboBoxj4v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v2.SelectedItem.ToString()), int.Parse(comboBoxj4v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v4.SelectedItem.ToString()), int.Parse(comboBoxj4v5.SelectedItem.ToString()) };
            List<int> j5 = new List<int> { int.Parse(comboBoxj5v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj5v2.SelectedItem.ToString()), int.Parse(comboBoxj5v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj5v4.SelectedItem.ToString()), int.Parse(comboBoxj5v5.SelectedItem.ToString()) };


            List<int> a1 = new List<int> { int.Parse(comboBoxj1v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v1.SelectedItem.ToString()), int.Parse(comboBoxj3v1.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v1.SelectedItem.ToString()), int.Parse(comboBoxj5v1.SelectedItem.ToString()) };
            List<int> a2 = new List<int> { int.Parse(comboBoxj1v2.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v2.SelectedItem.ToString()), int.Parse(comboBoxj3v2.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v2.SelectedItem.ToString()), int.Parse(comboBoxj5v2.SelectedItem.ToString()) };
            List<int> a3 = new List<int> { int.Parse(comboBoxj1v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v3.SelectedItem.ToString()), int.Parse(comboBoxj3v3.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v3.SelectedItem.ToString()), int.Parse(comboBoxj5v3.SelectedItem.ToString()) };
            List<int> a4 = new List<int> { int.Parse(comboBoxj1v4.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v4.SelectedItem.ToString()), int.Parse(comboBoxj3v4.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v4.SelectedItem.ToString()), int.Parse(comboBoxj5v4.SelectedItem.ToString()) };
            List<int> a5 = new List<int> { int.Parse(comboBoxj1v5.SelectedItem.ToString()), 
                int.Parse(comboBoxj2v5.SelectedItem.ToString()), int.Parse(comboBoxj3v5.SelectedItem.ToString()), 
                int.Parse(comboBoxj4v5.SelectedItem.ToString()), int.Parse(comboBoxj5v5.SelectedItem.ToString()) };

            List<player> t1 = new List<player>();
            List<player> t2 = new List<player>();

            t1.Add(new player { actif = true, number = 0, notes = j1 });
            t1.Add(new player { actif = true, number = 1, notes = j2 });
            t1.Add(new player { actif = true, number = 2, notes = j3 });
            t1.Add(new player { actif = true, number = 3, notes = j4 });
            t1.Add(new player { actif = true, number = 4, notes = j5 });
            t2.Add(new player { actif = true, number = 0, notes = a1 });
            t2.Add(new player { actif = true, number = 1, notes = a2 });
            t2.Add(new player { actif = true, number = 2, notes = a3 });
            t2.Add(new player { actif = true, number = 3, notes = a4 });
            t2.Add(new player { actif = true, number = 4, notes = a5 });
            generate(t1, t2);
        }

        /// <summary>
        /// Un joueur
        /// </summary>
        public class player
        {
            public bool actif;
            public int number;
            public List<int> notes = new List<int>();
        }

        /// <summary>
        /// Un noeud de l'arbre des appariements
        /// </summary>
        public class node
        {
            public int finalPoids;
            public bool isResultC1;
            //les poids correspondents à la somme des points possibles en dessous de l'appariement courant
            public int poidsC1;
            public int poidsC2;
            public player p1;
            public player clic1;
            public bool team1;
            public player clic2;
            public List<node> nodesC1 = new List<node>();
            public List<node> nodesC2 = new List<node>();
        }

        /// <summary>
        /// arbre de résultat des appariements
        /// </summary>
        List<node> results = new List<node>();

        /// <summary>
        /// fonction principale de génération de l'arbre des appariements
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public void generate(List<player> t1, List<player> t2)
        {
            //on génère l'arbre des appariements dans results
            var poids = calculate(t1, t2, null, results, checkBoxFirst.Checked);
            //génération du tableau des pairings à éviter
            List<List<int>> avoid = new List<List<int>>();
            if (!string.IsNullOrEmpty(textBoxAvoidj1.Text) && !string.IsNullOrEmpty(textBoxAvoida1.Text))
                avoid.Add(new List<int> { int.Parse(textBoxAvoidj1.Text) - 1, int.Parse(textBoxAvoida1.Text) - 1 });
            if (!string.IsNullOrEmpty(textBoxAvoidj2.Text) && !string.IsNullOrEmpty(textBoxAvoida2.Text))
                avoid.Add(new List<int> { int.Parse(textBoxAvoidj2.Text) - 1, int.Parse(textBoxAvoida2.Text) - 1 });
            if (!string.IsNullOrEmpty(textBoxAvoidj3.Text) && !string.IsNullOrEmpty(textBoxAvoida3.Text))
                avoid.Add(new List<int> { int.Parse(textBoxAvoidj3.Text) - 1, int.Parse(textBoxAvoida3.Text) - 1 });
            //modification de l'arbre final en fonction du paramétrage
            finalPath(results, avoid);
            treeView1.Nodes.Clear();
            //création de l'arbre d'affichage
            var basenode = new TreeNode("Pairings");
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.Nodes.Add(basenode);
            //génération de l'arbre d'affichage
            createTree(results, treeView1.Nodes[0].Nodes, t1, t2);
            basenode.Expand();
        }

        /// <summary>
        /// affiche dans le bandeau de droite le déroulé actuel de l'arbre choisi pour avoir une meilleure idée de l'appariement en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //je sais plus exactement ce que ça fait, mais ça marche. Ça a l'air compliqué
            var positions = getnodepairing(e.Node);
            positions.Reverse();
            positions.RemoveAt(0);
            if (positions.Count % 2 == 1)
                positions.RemoveAt(positions.Count - 1);
            var currentnode = results[0];
            var currentlist = results;
            for (var i = 0 ; i < positions.Count ; i = i +2)
            {
                currentnode = currentlist[positions[i]];
                var selectedadv = positions[i + 1] == 0 ? currentnode.clic1 : currentnode.clic2;
                var info = getlistpairing(currentnode, selectedadv);
                var item = new ListViewItem(info);
                item.BackColor = getcolor(currentnode, null, null, currentnode.team1, currentnode.p1.notes[selectedadv.number]);
                listViewfinal.Items.Add(item);
                currentlist = positions[i + 1] == 0 ? currentnode.nodesC1 : currentnode.nodesC2;
            }
            listViewfinal.Items.Add("----------------");
        }

        public string getlistpairing(node node, player adv)
        {
            string res = "";
            if (node.team1)
            {
                res += getName(node.p1.number, node.team1);
                res += " vs ";
                res += getName(adv.number, !node.team1);
                res += " (" + node.p1.notes[adv.number] + ")";
            }
            else
            {
                res += getName(adv.number, !node.team1);
                res += " vs ";
                res += getName(node.p1.number, node.team1);
                res += " (" + node.p1.notes[adv.number] + ")";
            }
            return res;
        }

        public List<int> getnodepairing(TreeNode node)
        {
            if (node != null)
            {
                List<int> positions = new List<int>();
                positions.Insert(0, node.Index);
                var res = getnodepairing(node.Parent);
                if (res != null)
                    positions.AddRange(res);
                return positions;
            }
            return null;
        }

        /// <summary>
        /// création récursive de l'arbre d'affichage avec tous les pairings
        /// </summary>
        /// <param name="result"></param>
        /// <param name="treenodes"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public void createTree(List<node> result, TreeNodeCollection treenodes, List<player> t1, List<player> t2)
        {
            //pour chaque node on l'affiche et on crée son sous-arbre
            foreach (var node in result)
            {
                var newnode = new TreeNode(getTreeStringMain(node, t1, t2));
                var child1 = new TreeNode(getTreeStringSecond(node, t1, t2, true));
                var child2 = new TreeNode(getTreeStringSecond(node, t1, t2, false));
                child1.BackColor = getcolor(node, t1, t2, true);
                child2.BackColor = getcolor(node, t1, t2, false);
                newnode.Nodes.Add(child1);
                newnode.Nodes.Add(child2);
                createTree(node.nodesC1, newnode.Nodes[0].Nodes, t1, t2);
                createTree(node.nodesC2, newnode.Nodes[1].Nodes, t1, t2);
                newnode.BackColor = getmaincolor(node, t1, t2);
                treenodes.Add(newnode);
            }
        }

        /// <summary>
        /// affichage de la couleur en fonction du pairing sélectionné
        /// </summary>
        /// <param name="node"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public Color getmaincolor(node node, List<player> t1, List<player> t2)
        {
            Color color = Color.Blue;
            List<player> table = node.team1 ? t1 : t2;
            var number = table[node.p1.number].notes[node.clic1.number] + table[node.p1.number].notes[node.clic2.number];
            if (number < 3) color = Color.LightBlue;
            else if (number < 5) color = Color.LightGreen;
            else if (number < 7) color = Color.LightYellow;
            else if (number < 9) color = Color.Orange;
            else if (number < 11) color = Color.Red;

            return color;
        }
        /// <summary>
        /// affichage de la couleur en fonction de la note
        /// </summary>
        /// <param name="node"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="first"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public Color getcolor(node node, List<player> t1, List<player> t2, bool first, int note = -1)
        {
            Color color = Color.Blue;
            List<player> table = node.team1 ? t1 : t2;
            if (note == -1)
                note = table[node.p1.number].notes[(first ? node.clic1.number : node.clic2.number)];
            switch (note)
            {
                case 1: color = Color.LightBlue; break;
                case 2: color = Color.LightGreen; break;
                case 3: color = Color.LightYellow; break;
                case 4: color = Color.Orange; break;
                case 5: color = Color.Red; break;
                default: color = Color.Red; break;
            }
            return color;
        }
        /// <summary>
        /// affichage des sous-lignes du nom du joueur et des notes possibles selon ses sous-arbres
        /// </summary>
        /// <param name="node"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public string getTreeStringSecond(node node, List<player> t1, List<player> t2, bool first)
        {
            string res = "";
            List<player> table = node.team1 ? t1 : t2;
            res += (node.p1.number + 1);
            res = getName(first ? node.clic1.number : node.clic2.number, !node.team1) + "(" + table[node.p1.number].notes[(first ? node.clic1.number : node.clic2.number)] + "|" + (first ? node.poidsC1 : node.poidsC2) + ")";

            return res;
        }
        /// <summary>
        /// affichage de la première ligne du nom du joueur et des notes possibles selon ses sous-arbres
        /// </summary>
        /// <param name="node"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public string getTreeStringMain(node node, List<player> t1, List<player> t2)
        {
            string res = "";

            List<player> table = node.team1 ? t1 : t2;
            res += (node.p1.number + 1);
            res = getName(node.p1.number, node.team1) + " - " + getName(node.clic1.number, !node.team1) + "(" + table[node.p1.number].notes[node.clic1.number] + "|" + node.poidsC1 + ")/" + getName(node.clic2.number, !node.team1) + "(" + table[node.p1.number].notes[node.clic2.number] + "|" + node.poidsC2 + ")";
            res = res + " | " + node.finalPoids;
            return res;
        }

        /// <summary>
        /// renvoie le nom du joueur en fonction de sa team et de sa position
        /// </summary>
        /// <param name="place"></param>
        /// <param name="team1"></param>
        /// <returns></returns>
        public string getName(int place, bool team1)
        {
            switch (place)
            {
                case 0: return team1 ? textBoxj1.Text : textBoxa1.Text;
                case 1: return team1 ? textBoxj2.Text : textBoxa2.Text;
                case 2: return team1 ? textBoxj3.Text : textBoxa3.Text;
                case 3: return team1 ? textBoxj4.Text : textBoxa4.Text;
                case 4: return team1 ? textBoxj5.Text : textBoxa5.Text;
                default: return "";
            }
        }

        /// <summary>
        /// fonction récursive principale de génération de l'arbre des appariements
        /// </summary>
        /// <param name="t1">la team 1 courante</param>
        /// <param name="t2">la team 2 courante</param>
        /// <param name="drop">Le joueur actuellement jeté</param>
        /// <param name="result">la liste des résultats</param>
        /// <param name="team1">si on est actuellement sur la team1 ou la team2</param>
        /// <returns></returns>
        public int calculate(List<player> t1, List<player> t2, player drop, List<node> result, bool team1)
        {
            int poids = 0;
            //pour chaque joueur actif
            foreach (player player in t1.Where(a => a.actif))
            {
                var p = player;
                //s'il y a un joueur jeté on le prend, sinon c'est le premier appariement
                if (drop != null)
                    p = drop;
                //on récupère tous les couples d'appariements possibles sans doublons
                List<List<int>> clic = getCouples(t2);
                //si on est au bout de l'arbre on crée simplement le noeud final, condition d'arrêt de la récursion
                if (clic.Count == 0 && t2.Count == 1)
                {
                    var node = new node { team1 = team1, poidsC1 = p.notes[t2[0].number], poidsC2 = p.notes[t2[0].number], p1 = p, clic1 = t2[0], clic2 = t2[0], nodesC1 = new List<node>(), nodesC2 = new List<node>() };
                    result.Add(node);
                    poids += p.notes[t2[0].number];
                }
                //pour chaque couple d'appariement
                foreach (var doublon in clic)
                {
                    //on récupère les 2 joueurs concernés
                    var clic1 = getPlayer(t2, doublon[0]);
                    var clic2 = getPlayer(t2, doublon[1]);
                    var childs1 = new List<node>();
                    //on génère l'arbre dans le cas où le joueur 1 est choisi
                    var childPoids1 = calculate(t2.Where(a => a != clic1).ToList<player>(), t1.Where(a => a != p).ToList<player>(), clic2, childs1, !team1);
                    var childs2 = new List<node>();
                    //on génère l'arbre dans le cas où le joueur 2 est choisi
                    var childPoids2 = calculate(t2.Where(a => a != clic2).ToList<player>(), t1.Where(a => a != p).ToList<player>(), clic1, childs2, !team1);
                    //création du node correspondant au choix en cours, qui contient déjà tous ses arbres possibles et son poids
                    var node = new node { team1 = team1, poidsC1 = p.notes[clic1.number] + childPoids1, poidsC2 = p.notes[clic2.number] + childPoids2, p1 = p, clic1 = clic1, clic2 = clic2, nodesC1 = childs1, nodesC2 = childs2 };
                    result.Add(node);
                    //calcul du poids total du node
                    poids += childPoids1 + childPoids2 + p.notes[clic1.number] + p.notes[clic2.number];
                }
                if (drop != null)
                    break;
            }
            return poids;
        }

        public class result
        {
            public int position;
            public bool player1;
        }

        /// <summary>
        /// modifie l'arbre en appliquant les bonus et un surpoids pour les nodes à éviter
        /// </summary>
        /// <param name="pairing"></param>
        /// <param name="avoid"></param>
        /// <returns></returns>
        public int finalPath(List<node> pairing, List<List<int>> avoid)
        {
            var bonus = 0;
            int.TryParse(textBoxBonus5.Text, out bonus);
            int min = 0;
            int max = 0;
            bool isTeam1 = true;
            //pour chaque pairing actuel
            foreach (var node in pairing)
            {
                isTeam1 = node.team1;
                var poidstmp = 0;
                //modification récursive des pairings sous le node actuel, si la note est à 0 on applique le bonus de poids défini
                var poidsC1 = finalPath(node.nodesC1, avoid) + (node.p1.notes[node.clic1.number] == 5 ? node.p1.notes[node.clic1.number] + bonus : node.p1.notes[node.clic1.number]);
                //on ajoute 100 au poids si on doit éviter ce pairing pour que les arbres à éviter soient clairement visibles
                if (testAvoid(avoid, node.p1.number, node.clic1.number))
                    poidsC1 += 100;
                var poidsC2 = finalPath(node.nodesC2, avoid) + (node.p1.notes[node.clic2.number] == 5 ? node.p1.notes[node.clic2.number] + bonus : node.p1.notes[node.clic2.number]);
                if (testAvoid(avoid, node.p1.number, node.clic2.number))
                    poidsC2 += 100;
                //si on est en team1 le poids qui nous intéresse c'est le poids min vu que c'est celui qu'on va choisir
                if (isTeam1)
                {
                    poidstmp = Math.Min(poidsC1, poidsC2);
                    node.isResultC1 = Math.Min(poidsC1, poidsC2) == poidsC1;
                    //le poids final du node est le max des min, les min parce que c'est nous qui choisissons quel joueur on met et le max parce que c'est l'adversaire qui choisit entre ces joueurs
                    if (min == 0)
                        min = poidstmp;
                    else
                        min = Math.Max(poidstmp, min);
                }
                //si on est en team2 le poids qui nous intéresse c'est le poids max vu que c'est celui que va choisir la team adverse
                else
                {
                    poidstmp = Math.Max(poidsC1, poidsC2);
                    node.isResultC1 = Math.Max(poidsC1, poidsC2) == poidsC1;
                    //le poids final du node est le min des max, les max parce que c'est l'adversaire qui choisit quels joueurs il met et le min parce que c'est nous qui choisissons entre ces joueurs
                    if (max == 0)
                        max = poidstmp;
                    else
                        max = Math.Min(poidstmp, max);
                }
                node.poidsC1 = poidsC1;
                node.poidsC2 = poidsC2;
                node.finalPoids = poidstmp;
            }
            return isTeam1 ? min : max;
        }

        /// <summary>
        /// sert à vérifier si le couple de joueurs p1 et p2 est dans le tableau des pairings à éviter
        /// </summary>
        /// <param name="avoid"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public bool testAvoid(List<List<int>> avoid, int p1, int p2)
        {
            bool exist = false;
            foreach (var elt in avoid)
            {
                if (elt[0] == p1 && elt[1] == p2)
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }

        /// <summary>
        /// récupère un joueur à partir de son numéro
        /// </summary>
        /// <param name="t"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public player getPlayer(List<player> t, int number)
        {
            foreach (player p in t)
            {
                if (p.number == number)
                    return p;
            }
            return null;
        }
        /// <summary>
        /// génère tous les couples possibles de joueurs actifs à partir d'une liste de joueur, optimisable
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<List<int>> getCouples(List<player> t)
        {
            List<List<int>> res = new List<List<int>>();
            //double boucle sur les joueurs actifs
            foreach (player p in t.Where(a => a.actif))
            {
                foreach (player c in t.Where(a => a.actif))
                {
                    if (p.number != c.number)
                    {
                        List<int> tmp = new List<int> { p.number, c.number };
                        bool doublon = false;
                        foreach (var tmp2 in res)
                        {
                            //vérification si ce n'est pas un doublon dans la liste
                            if ((tmp2[0] == tmp[0] && tmp2[1] == tmp[1]) || (tmp2[1] == tmp[0] && tmp2[0] == tmp[1]))
                            {
                                doublon = true;
                                break;
                            }
                        }
                        //ajout dans la liste
                        if (!doublon)
                            res.Add(tmp);
                    }
                }
            }
            return res;
        }

        private void buttonEmpty_Click(object sender, EventArgs e)
        {
            listViewfinal.Clear();
        }

        private void buttonLists_Click(object sender, EventArgs e)
        {
            lists.Show();
        }
    }
}
