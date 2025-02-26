﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PrototypeUI
{
    public partial class Form1 : Form
    {
        private int[,] graph;
        private List<String> node;
        private List<int> visited;
        private List<String> path = new List<String>();
        private Microsoft.Msagl.Drawing.Graph graph_pic;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbb_Feature.Enabled = false;
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;
            this.Cbb_1.Enabled = false;
            this.Cbb_2.Enabled = false;
            this.btn_submit.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        // button browse
        private void button1_Click(object sender, EventArgs e) //Browse
        {
            this.SuspendLayout();
            this.panelViewer.Controls.Clear();
            this.ResumeLayout();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.



            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    this.cbb_Feature.Enabled = true;
                    this.btn_submit.Enabled = true;

                    string[] text = File.ReadAllLines(file);
                    size = text.Length;
                    parsingFile(text);

                    this.lbl_filename.Text = (Path.GetFileName(file));


                }
                catch (IOException)
                {
                }
            }
        }

        private void parsingFile(string[] lines)
        {
            this.Cbb_1.Items.Clear();
            this.Cbb_2.Items.Clear();

            visited = new List<int>();
            int length = int.Parse(lines[0]);
            graph_pic = new Microsoft.Msagl.Drawing.Graph("graph");

            // list of string orang ini dipake buat nampung nama-nama di string[] lines
            var orang = new List<string>();
            string[] baris;

            // 
            for (int i = 1; i < lines.Length; i++)
            {
                baris = lines[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                foreach (string j in baris)
                {
                    orang.Add(j);
                }
            }

            // habis itu diambil aja bagian yg "unik"-nya
            node = orang.Distinct().ToList();

            // list orang diclear karena ga ada guna lagi
            orang.Clear();

            // node disorting biar sesuai abjad (ascend)
            node.Sort();

            // add simpul to combobox 1
            foreach (string j in node)
            {
                visited.Add(0);
                this.Cbb_1.Items.Add(j);
            }

            graph = new int[node.Count, node.Count];

            for (int i = 0; i < node.Count; i++)
            {
                for (int j = 0; j < node.Count; j++)
                {
                    graph[i, j] = 0;
                }
            }

            string[] lines2;

            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 

            for (int i = 1; i < lines.Length; i++)
            {
                //create the graph content 
                lines2 = lines[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                var edge = graph_pic.AddEdge(lines2[0], lines2[1]);
                edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                graph[node.IndexOf(lines2[0]), node.IndexOf(lines2[1])] = 1;
                graph[node.IndexOf(lines2[1]), node.IndexOf(lines2[0])] = 1;

            }

            //bind the graph to the viewer 
            viewer.Graph = graph_pic;
            viewer.Name = "graphViewer";
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;

            //associate the viewer with the form 
            this.SuspendLayout();
            this.panelViewer.Controls.Add(viewer);
            this.ResumeLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void lbl_filename_Click(object sender, EventArgs e)
        {

        }

        private void Cbb_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = this.Cbb_1.Items[Cbb_1.SelectedIndex].ToString();
            foreach (string node1 in node)
            {
                this.Cbb_2.Items.Remove(node1);
            }
            foreach (string node1 in node)
            {
                if (node1 != selected)
                {
                    this.Cbb_2.Items.Add(node1);
                }
            }

        }

        private void Cbb_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clearVisited()
        {
            int len = node.Count;
            for (int i = 0; i < len; i++)
            {
                visited[i] = 0;
            }
        }

        private List<int> tetangga(int nodeid)
        {
            List<int> ret = new List<int>();
            int n = node.Count;
            for (int i = 0; i < n; i++)
            {
                if (graph[nodeid, i] == 1)
                {
                    ret.Add(i);
                }
            }
            ret.Sort();
            return ret;
        }

        private int[,] EmptyGraphWithEdge(int i1, int i2)
        {
            int n = node.Count;
            int[,] ret = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ret[i, j] = 0;
                }
            }
            ret[i1, i2] = 1;
            ret[i2, i1] = 1;
            return ret;
        }

        private int[,] addMatrix(int[,] a, int[,] b)
        {
            int n = node.Count;
            int[,] c = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }

        private int[,] dfs(int idawal, int idtarget)
        {
            // mencari tetangga
            List<int> ttg = tetangga(idawal);

            // menandai simpul sudah dikunjungi
            visited[idawal] = 1;

            // basis, apabila simpul tujuan dan awal bersebelahan,
            // akan dicek dulu apakah ada simpul lain yang belum dikunjungi tetapi memiliki prioritas tertinggi,
            // yaitu memiliki abjad yang lebih rendah
            if (graph[idawal, idtarget] == 1)
            {
                for (int i = 0; i < ttg.Count; i++)
                {
                    if (visited[ttg[i]] == 0)
                    {
                        // apabila tidak ada tetangga lain yang memiliki abjad lebih rendah dan langsung solusi, maka selesaikan
                        if (ttg[i] == idtarget)
                        {
                            path.Add(node[idtarget]);
                            path.Add(node[idawal]);
                            return EmptyGraphWithEdge(idawal, idtarget);
                        }
                        // apabila ternyata ada simpul dengan abjad lebih rendah maka akan dikunjungi terlebih dahulu dgn metode DFS
                        else
                        {
                            int[,] otw = dfs(ttg[i], idtarget);
                            if (otw != null)
                            {
                                path.Add(node[idawal]);
                                int[,] ret = EmptyGraphWithEdge(idawal, ttg[i]);
                                return addMatrix(ret, otw);
                            }
                        }
                    }
                }
            }
            else
            {
                // traversal dengan metode DFS, dikunjungi salah satu simpul sampai buntu
                // lalu melanjutkan ke simpul lainnya apabila buntu
                for (int i = 0; i < ttg.Count; i++)
                {
                    if (visited[ttg[i]] == 0)
                    {
                        int[,] otw = dfs(ttg[i], idtarget);
                        if (otw != null)
                        {
                            path.Add(node[idawal]);
                            int[,] ret = EmptyGraphWithEdge(idawal, ttg[i]);
                            return addMatrix(ret, otw);
                        }
                    }
                }
            }
            return null;
        }

        private void cbb_Feature_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cbb_1.Enabled = true;
            string FriendRecom = "Friends Recommendation";
            if (this.cbb_Feature.SelectedItem.ToString() == FriendRecom)
            {
                this.Cbb_2.Enabled = false;

                // Friend Recom tidak dependent terhadap algoritma dfs/bfs apa yang dipakai
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;

                //this.Cbb_1.Items.Clear();
                this.Cbb_1.ResetText();

                //this.Cbb_2.Items.Clear();
                this.Cbb_2.ResetText();
            }
            else
            {
                this.Cbb_2.Enabled = true;
                this.radioButton1.Enabled = true;
                this.radioButton2.Enabled = true;
                this.Cbb_1.ResetText();
                this.Cbb_2.ResetText();
            }
        }
        private void addColorFromMatrix(int[,] colorMatrix)
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph_pic2 = new Microsoft.Msagl.Drawing.Graph("graph");
            int n = node.Count;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && i < j && graph[i, j] == 1)
                    {
                        var edge = graph_pic2.AddEdge(node[i], node[j]);
                        edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        if (colorMatrix[i, j] == 1)
                        {
                            edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                            graph_pic2.FindNode(node[i]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                            graph_pic2.FindNode(node[j]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                        }
                    }
                }
            }

            viewer.Graph = graph_pic2;
            viewer.Name = "graphViewer";
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;

            this.SuspendLayout();
            this.panelViewer.Controls.Clear();
            this.panelViewer.Controls.Add(viewer);
            this.ResumeLayout();
        }
        //
        private void resetGraph()
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Graph = graph_pic;
            viewer.Name = "graphViewer";
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;

            this.SuspendLayout();
            this.panelViewer.Controls.Clear();
            this.panelViewer.Controls.Add(viewer);
            this.ResumeLayout();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            //this.cbb_Feature.SelectedItem = n;
            this.cbb_Feature.ResetText();

            //this.Cbb_1.Items.Clear();
            this.Cbb_1.ResetText();

            //this.Cbb_2.Items.Clear();
            this.Cbb_2.ResetText();
            //dfs button
            this.radioButton1.Checked = false;
            //bfs button
            this.radioButton2.Checked = false;
            resetGraph();

            this.textBox1.Text = "";

        }

        private bool BFS(string str, List<string> orang_dist, int[,] matrix_adj, string target, int[] pred, int[] dist)
        {

            // Cari dulu index dari target
            int idx_target = orang_dist.IndexOf(target);
            int v = orang_dist.Count;

            // Array boolean, representasi yg udah divisit
            bool[] visited = new bool[v];

            int start = orang_dist.IndexOf(str);

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
                dist[i] = 99999;
                pred[i] = -1;
            }

            List<int> q = new List<int>();
            q.Add(start);

            // Source sudah dikunjungi
            visited[start] = true;
            dist[start] = 0;
            int[,] matrix_adj_new = new int[orang_dist.Count, orang_dist.Count];

            int vis;

            while (q.Count != 0)
            {
                vis = q[0];

                // cetak node sekarang
                Console.Write(orang_dist[vis] + " ");
                q.Remove(q[0]);

                // Untuk setiap tetangga nya node sekarang
                for (int i = 0; i < v; i++)
                {
                    if (matrix_adj[vis, i] == 1 && (!visited[i]))
                    {
                        // Push tetangga ke node
                        q.Add(i);
                        q.Sort();

                        // Set kalo telah dikunjungi
                        visited[i] = true;
                        dist[i] = dist[vis] + 1;
                        pred[i] = vis;
                        matrix_adj_new[vis, i] = 1;
                        matrix_adj_new[i, vis] = 1;
                        if (visited[idx_target])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void printBFS(string str, List<string> orang_dist, int[,] matrix_adj, string target)
        {
            int[] pred = new int[orang_dist.Count];
            int[] dist = new int[orang_dist.Count];

            if (!BFS(str, orang_dist, matrix_adj, target, pred, dist))
            {
                Console.Write("Nama Akun " + str + " " + target + "\n");
                Console.Write("Tidak ada jalur koneksi yang tersedia\n");
                Console.Write("Anda harus memulai koneksi baru itu sendiri\n");
                String outputBFS = "";
                outputBFS += "Nama Akun: " + str + " dan " + target + "\r\n";
                outputBFS += "Tidak ada jalur koneksi yang tersedia\r\nAnda harus memulai koneksi baru itu sendiri.";
                this.textBox1.Text = outputBFS;
            }

            else
            {
                String outputBFS = "";
                outputBFS += "Nama Akun: " + str + " dan " + target + "\r\n";

                List<int> path = new List<int>();
                int crawl = orang_dist.IndexOf(target);
                path.Add(crawl);
                while (pred[crawl] != -1)
                {
                    path.Add(pred[crawl]);
                    crawl = pred[crawl];
                }
                Console.Write("Path terpendek adalah ");
                Console.Write(dist[orang_dist.IndexOf(target)] - 1);
                Console.WriteLine("");
                Console.WriteLine("Path is");
                string stndrd = "";
                int deg = path.Count() - 2;
                if (deg % 100 >= 11 && deg % 100 <= 19)
                {
                    stndrd = "th";
                }
                else
                {
                    int mod = deg % 10;
                    if (mod == 1)
                    {
                        stndrd = "st";
                    }
                    else if (mod == 2)
                    {
                        stndrd = "nd";
                    }
                    else if (mod == 3)
                    {
                        stndrd = "rd";
                    }
                    else
                    {
                        stndrd = "th";
                    }
                }
                outputBFS += deg + stndrd + "-degree connection\r\n";



                for (int i = path.Count - 1; i >= 0; i--)
                {
                    Console.Write(orang_dist[path[i]] + " ");
                    if (i == 0)
                    {
                        outputBFS += orang_dist[path[i]];
                    }
                    else
                    {
                        outputBFS += orang_dist[path[i]] + " -> ";
                    }
                }
                this.textBox1.Text = outputBFS;

                int[,] matrix_adj_new = new int[orang_dist.Count, orang_dist.Count];
                for (int i = 0; i < path.Count - 1; i++)
                {
                    matrix_adj_new[path[i], path[i + 1]] = 1;
                    matrix_adj_new[path[i + 1], path[i]] = 1;
                }
                addColorFromMatrix(matrix_adj_new);
            }
        }

        private void printDFS(string account, string target)
        {
            int accidx = node.FindIndex(name => name == account);
            int targetidx = node.FindIndex(name => name == target);
            int[,] result = dfs(accidx, targetidx);
            String output = "";
            output += "Nama Akun: " + node[accidx] + " dan " + node[targetidx] + "\r\n";
            if (result != null)
            {
                String stndrd = "";
                int deg = path.Count() - 2;
                if (deg % 100 >= 11 && deg % 100 <= 19)
                {
                    stndrd = "th";
                }
                else
                {
                    int mod = deg % 10;
                    if (mod == 1)
                    {
                        stndrd = "st";
                    }
                    else if (mod == 2)
                    {
                        stndrd = "nd";
                    }
                    else if (mod == 3)
                    {
                        stndrd = "rd";
                    }
                    else
                    {
                        stndrd = "th";
                    }
                }
                output += deg + stndrd + "-degree connection\r\n";
                path.Reverse();
                for (int i = 0; i < path.Count(); i++)
                {
                    output += path[i];
                    if (i < path.Count() - 1)
                    {
                        output += " -> ";
                    }
                }
                Console.WriteLine(output);
                addColorFromMatrix(result);
            }
            else
            {
                output += "Tidak ada jalur koneksi yang tersedia\r\nAnda harus memulai koneksi baru itu sendiri.";
            }
            path.Clear();
            clearVisited();
            this.textBox1.Text = output;
        }

        void printRecommendation(string account)
        {
            int accidx = node.FindIndex(name => name == account);
            string output = "";

            List<int> tetanggaaccount = tetangga(accidx);
            List<int> friendwithmutual = new List<int>();
            List<int> friendwithmutualdist;
            List<(int, int, List<int>)> mutualtuple = new List<(int, int, List<int>)>();
            // tuple value <int nodeid, int mutualcount, List<int> mutualnodeid>

            foreach (int ttg in tetanggaaccount)
            {
                foreach (int ttg2 in tetangga(ttg))
                {
                    bool idx = tetanggaaccount.FindIndex(x => x == ttg2) != -1;
                    if (!idx && ttg2 != accidx) friendwithmutual.Add(ttg2);
                }
            }

            friendwithmutualdist = friendwithmutual.Distinct().ToList();

            for (int i = 0; i < friendwithmutualdist.Count; i++)
            {
                int ttg = friendwithmutualdist[i];
                int count = friendwithmutual.Where(x => x == ttg).Count();
                List<int> mutual = new List<int>();
                foreach (int ttg2 in tetangga(ttg))
                {
                    bool idx = tetanggaaccount.FindIndex(x => x == ttg2) != -1;
                    if (idx) mutual.Add(ttg2);
                }
                mutualtuple.Add((ttg, count, mutual));
            }

            mutualtuple.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            foreach ((int, int, List<int>) a in mutualtuple)
            {
                Console.Write("Nama akun: ");
                Console.WriteLine(node[a.Item1]);
                output += "Nama akun: \r\n" + node[a.Item1] + "\r\n";
                Console.Write("Total mutual: ");
                Console.WriteLine(a.Item2);
                output += "Total mutual: " + a.Item2 + "\r\n";
                Console.Write("Mutualnya: ");

                output += "Mutualnya: \r\n";
                foreach (int mut in a.Item3)
                {
                    Console.Write(node[mut] + " ");
                    output += node[mut] + " ";


                }
                Console.WriteLine();
                output += "\r\n\r\n";
            }
            Console.WriteLine("ini stringnya:");
            Console.WriteLine(output);
            this.textBox1.Multiline = true;
            this.textBox1.Text = output;
        }

        private void btn_submit_Click_1(object sender, EventArgs e)
        {
            string FriendRecom = "Friends Recommendation";

            if (this.cbb_Feature.SelectedIndex == -1 || this.Cbb_1.SelectedIndex == -1)
            {
                return;
            }

            string selecteditem = this.cbb_Feature.SelectedItem.ToString();
            resetGraph();


            String account = this.Cbb_1.Items[Cbb_1.SelectedIndex].ToString();
            if (selecteditem == FriendRecom)
            {
                printRecommendation(account);
            }
            else
            {
                if (this.Cbb_2.SelectedIndex == -1)
                {
                    return;
                }
                String type = "";
                String target = this.Cbb_2.Items[Cbb_2.SelectedIndex].ToString();

                if (this.radioButton1.Checked && !this.radioButton2.Checked)
                {
                    type = "dfs";
                }
                else if (!this.radioButton1.Checked && this.radioButton2.Checked)
                {
                    type = "bfs";
                }


                if (type == "dfs")
                {
                    printDFS(account, target);
                }
                else if (type == "bfs")
                {
                    printBFS(account, node, graph, target);

                }

            }

        }

        private void panel_output_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelViewer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
