using System;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace ERP_COMPLETO
{
    public partial class ESPECIFICACIONES_TECNICAS : Form
    {
        public ESPECIFICACIONES_TECNICAS()
        {
            InitializeComponent();
        }
        private void MostrarInformacionDelSistema()
        {
            // Asignar la información a cada TextBox
            txtNombrePC.Texts = ObtenerNombrePC();
            txtSSDInfo.Texts = ObtenerDiscoYNumeroSerie();
            txtRAM.Texts = ObtenerTotalRAM();
            txtAlmacenamiento.Texts = ObtenerPorcentajeAlmacenamiento() + "%";
            txtAdaptadorRed.Texts = ObtenerAdaptadorRed();
            txtSistemaOperativo.Texts = ObtenerSistemaOperativo();
            txtProcesador.Texts = ObtenerProcesador();
            txtEdicionWindows.Texts = ObtenerEdicionWindows();
        }

        private string ObtenerNombrePC()
        {
            return Environment.MachineName;
        }

        private string ObtenerTotalRAM()
        {
            ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");
            ulong totalRAM = 0;

            foreach (ManagementObject obj in ramSearcher.Get())
            {
                totalRAM += (ulong)obj["Capacity"];
            }

            return (totalRAM / (1024 * 1024 * 1024)).ToString() + " GB";
        }

        private string ObtenerDiscoYNumeroSerie()
        {
            ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher("SELECT Model, SerialNumber FROM Win32_DiskDrive");
            string diskInfo = "";

            foreach (ManagementObject obj in diskSearcher.Get())
            {
                diskInfo += $"Modelo: {obj["Model"]}, Número de Serie: {obj["SerialNumber"]}\n";
            }

            return diskInfo.Trim();
        }

        private string ObtenerPorcentajeAlmacenamiento()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                {
                    double usedSpace = drive.TotalSize - drive.AvailableFreeSpace;
                    double usedPercentage = (usedSpace / drive.TotalSize) * 100;
                    return usedPercentage.ToString("F2"); // Formato con dos decimales
                }
            }
            return "No disponible";
        }

        private string ObtenerAdaptadorRed()
        {
            string adaptadorInfo = "";
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                adaptadorInfo += $"Nombre: {adapter.Name}, Tipo: {adapter.NetworkInterfaceType}, Estado: {adapter.OperationalStatus}\n";
            }
            return adaptadorInfo.Trim();
        }

        private string ObtenerSistemaOperativo()
        {
            return $"{Environment.OSVersion}";
        }

        private string ObtenerProcesador()
        {
            ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
            string processorName = "";

            foreach (ManagementObject obj in processorSearcher.Get())
            {
                processorName += $"{obj["Name"]}\n";
            }

            return processorName.Trim();
        }

        private string ObtenerEdicionWindows()
        {
            string edicion = "";
            ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");

            foreach (ManagementObject obj in osSearcher.Get())
            {
                edicion = obj["Caption"].ToString();
            }

            return edicion;
        }
        private void ESPECIFICACIONES_TECNICAS_Load(object sender, EventArgs e)
        {
            MostrarInformacionDelSistema();
        }
    }
}
