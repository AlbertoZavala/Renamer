using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileRenamer
{
    public partial class Renamer : Form {
        private Regex regex = new Regex(":");
        private string dateTimeFormat = "yyyy-MM-dd_HH.mm.ss";

        public Renamer() {
            InitializeComponent();
        }

        private void btnSearchClick(object sender, EventArgs e) {        
            
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() != DialogResult.OK)
                return;

            txtPath.Text = folderBrowser.SelectedPath;
        }
        private void btnRenameClick(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("¿Iniciará el renombramiento de todos los archivos?", "Alerta", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
                return;

            if (string.IsNullOrEmpty(txtPath.Text)) {
                MessageBox.Show("Debe seleccionar una ruta primero.");
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(txtPath.Text);
            FileInfo[] filesInfo;

            if (chkIncludeSubFolders.Checked) {
                filesInfo = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
            }
            else {
                filesInfo = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
            }

            foreach (FileInfo fileInfo in filesInfo) {
                if (chkCreationDate.Checked) {
                    RenameFileToCreationDateTime(fileInfo);                   
                }
            }

            MessageBox.Show("El proceso finalizó correctamente.");
        }

        private void RenameFileToCreationDateTime(FileInfo fileInfo) {
            string dateTaken = string.Empty;

            if (fileInfo.Extension.Equals(".jpg") || fileInfo.Extension.Equals("jpeg")
                || fileInfo.Extension.Equals("png") || fileInfo.Extension.Equals("gif")) {

                if (fileInfo.Name == "20150428_211516.jpg") {
                    var yy = "stop";
                }

                try {
                    using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                        try {
                            using (Image image = Image.FromStream(fileStream, false, false)) {
                                // Agregar Videos Media
                                if (image.PropertyIdList.Any(p => p == 36867)) {
                                    PropertyItem propertyItem = image.GetPropertyItem(36867);
                                    string dateTakenString = Encoding.UTF8.GetString(propertyItem.Value);
                                    DateTime dateTime = DateTime.Parse(regex.Replace(dateTakenString, "-", 2));
                                    dateTaken = dateTime.ToString(dateTimeFormat);
                                }
                                else {
                                    dateTaken = fileInfo.LastWriteTime.ToString(dateTimeFormat);
                                }
                            }
                        }
                        catch (ArgumentException ex) {
                            // Image with damage.
                            dateTaken = fileInfo.LastWriteTime.ToString(dateTimeFormat);
                        }
                    
                }
                catch (FormatException ex) {
                    dateTaken = fileInfo.LastWriteTime.ToString(dateTimeFormat);
                    var message = ex.Message;
                }
            }
            else {
                dateTaken = fileInfo.LastWriteTime.ToString(dateTimeFormat);
            }

            var newFileName = Path.Combine(fileInfo.DirectoryName, dateTaken + fileInfo.Extension);

            if (newFileName == fileInfo.FullName)
                return;

            if (fileInfo.Name.Contains(dateTaken))
                return;

            if (File.Exists(newFileName)) {                         
                string[] files = Directory.GetFiles(fileInfo.DirectoryName);
                int quantitySameNameFiles = files.Count(file => { return file.Contains(dateTaken); }) + 1;
                newFileName = Path.Combine(fileInfo.DirectoryName, dateTaken + "_" + quantitySameNameFiles + fileInfo.Extension);
            }

            File.Copy(fileInfo.FullName, newFileName);
            File.Delete(fileInfo.FullName);
        }
    }
}
