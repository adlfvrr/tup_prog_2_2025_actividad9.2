using ej1.Models.Exportadores;
using ej1.Models;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace ej1;
public partial class Form1 : Form
{
    List<IExportable> multas = new List<IExportable>();
    public Form1()
    {
        InitializeComponent();
    }

    private void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {
            IExportable nuevo = null;
            string patente = tbPatente.Text;
            DateOnly vencimiento = new DateOnly(dtpVencimiento.Value.Year, dtpVencimiento.Value.Month, dtpVencimiento.Value.Day);
            double importe = Convert.ToDouble(tbImporte.Text);
            nuevo = new Multa(patente, vencimiento, importe);
            multas.Sort();
            int idx = multas.BinarySearch(nuevo);
            if (idx >= 0)
            {
                Multa? multa = multas[idx] as Multa;
                multa.Importe += importe;
                if (multa.Vencimiento < ((Multa)nuevo).Vencimiento)
                {
                    multa.Vencimiento = ((Multa)nuevo).Vencimiento;
                }
                btnActualizar.PerformClick();
            }
            else
            {
                multas.Add(nuevo);
            }
            lsbVer.Items.Add(nuevo);
        }
        catch (FormatoPatenteNoValidaException ex) { MessageBox.Show(ex.Message); }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        tbImporte.Clear(); tbPatente.Clear();
    }

    private void btnActualizar_Click(object sender, EventArgs e)
    {
        lsbVer.Items.Clear();
        lsbVer.Items.AddRange(multas.ToArray());
    }

    private void btnImportar_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "(csv)|*.csv|(xml)|*.xml|(txt)|*.txt|(json)|*.json";
        FileStream fs = null;
        StreamReader sr = null;
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog1.FileName;
            int tipo = openFileDialog1.FilterIndex;
            IExportador exportador = (new ExportadorFactory()).GetInstance(tipo);
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    IExportable nuevo = new Multa();
                    if (nuevo.Importar(line, exportador))
                    {

                        multas.Add(nuevo);
                    }
                }
            }
            catch (FormatoPatenteNoValidaException ex) { MessageBox.Show(ex.Message); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    private void btnExportar_Click(object sender, EventArgs e)
    {
        saveFileDialog1.Filter = "(csv)|*.csv|(xml)|*.xml|(txt)|*.txt|(json)|*.json";
        FileStream fs = null;
        StreamWriter sw = null;
        try
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                int tipo = saveFileDialog1.FilterIndex;
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                IExportador exportador = (new ExportadorFactory()).GetInstance(tipo);
                foreach (IExportable multa in multas)
                {
                    string line = multa.Exportar(exportador);
                    if (line != null)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            if (sw != null) { sw.Close(); }
            if (fs != null) { fs.Close(); }
        }
        catch (FormatoPatenteNoValidaException ex) { MessageBox.Show(ex.Message); }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        string path = Path.Combine(Application.StartupPath, "ejemplo.dat");
        FileStream fs = null;
        try
        {
            fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
#pragma warning disable SYSLIB0011 // El tipo o el miembro están obsoletos
            BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // El tipo o el miembro están obsoletos
            bf.Serialize(fs, multas);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally
        {
            if (fs != null) { fs.Close(); }
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        FileStream fs = null;
        try {
            fs = new FileStream("ejemplo.dat", FileMode.OpenOrCreate, FileAccess.Read);
#pragma warning disable SYSLIB0011 // El tipo o el miembro están obsoletos
            BinaryFormatter bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // El tipo o el miembro están obsoletos
            this.multas = (List<IExportable>)bf.Deserialize(fs);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally { if (fs != null) fs.Close(); }
        btnActualizar.PerformClick();
        }
}
