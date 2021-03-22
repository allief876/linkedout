using System;
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
        private Microsoft.Msagl.Drawing.Graph graph_pic = new Microsoft.Msagl.Drawing.Graph("graph");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string[] text = File.ReadAllLines(file);
                    size = text.Length;
                    Console.WriteLine(text);
                    parsingFile(text);

                    this.lbl_filename.Text =(Path.GetFileName(file));
                    

                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.       
            //Console.WriteLine(this.Cbb_1.Items[Cbb_1.SelectedIndex].ToString());
        }

        private void parsingFile(string[] lines)
        {
            visited = new List<int>();
            int length = int.Parse(lines[0]);

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
            

            //graph_pic.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            //graph_pic.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
            //create the graph content 

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
            //associate the viewer with the form 
            this.SuspendLayout();

            //viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.Controls.Add(viewer);
            
           
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
            List<int> ttg = tetangga(idawal);

            visited[idawal] = 1;
            if (graph[idawal, idtarget] == 1)
            {
                for (int i = 0; i < ttg.Count; i++)
                {
                    if (visited[ttg[i]] == 0)
                    {
                        if (ttg[i] == idtarget)
                        {
                            return EmptyGraphWithEdge(idawal, idtarget);
                        }
                        else
                        {
                            int[,] otw = dfs(ttg[i], idtarget);
                            if (otw != null)
                            {
                                int[,] ret = EmptyGraphWithEdge(idawal, ttg[i]);
                                return addMatrix(ret, otw);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < ttg.Count; i++)
                {
                    if (visited[ttg[i]] == 0)
                    {
                        int[,] otw = dfs(ttg[i], idtarget);
                        if (otw != null)
                        {
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
            string FriendRecom = "Friends Recommendation";
            if (this.cbb_Feature.SelectedItem.ToString() == FriendRecom )
            {
                this.Cbb_2.Enabled = false;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
            }
            else
            {
                this.Cbb_2.Enabled = true;
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
                            edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                            graph_pic2.FindNode(node[i]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                            graph_pic2.FindNode(node[j]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                        }
                    }
                }
            }

            viewer.Graph = graph_pic2;
            viewer.Name = "graphViewer";

            this.SuspendLayout();
            this.panelViewer.Controls.Clear();
            this.panelViewer.Controls.Add(viewer);
            this.ResumeLayout();
        }
        private void resetGraph()
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            viewer.Graph = graph_pic;
            viewer.Name = "graphViewer";

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

        }
    }
}
