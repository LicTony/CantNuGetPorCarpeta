using CantNuggerPorCarpeta.Modelos;
using System.Configuration;
using System.Windows.Forms;

namespace CantNuggerPorCarpeta
{
    public partial class Main : Form
    {

        #region Constructor
        public Main()
        {
            InitializeComponent();
            string? rootPath = ConfigurationManager.AppSettings["RootPath"] ?? string.Empty;

            TxtRootPath.Text = rootPath;

            ActualizarStatus("");


            DgvDirectorios.AutoGenerateColumns = false;

            // Columna Path
            DgvDirectorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Path",
                HeaderText = "Ruta"
            });

            // Columna CantDirectorios
            DgvDirectorios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CantDirectorios",
                HeaderText = "Cantidad"
            });

            // Columna de botón
            var botonCol = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Limpiar",
                UseColumnTextForButtonValue = true,
                Name = "btnLimpiar"
            };
            DgvDirectorios.Columns.Add(botonCol);



            // Suscribirse al evento
            DgvDirectorios.CellClick += DgvDirectorios_CellClick;

            DgvDirectorios.DataSource = new List<DirectorioALimpiar>();
            DgvDirectorios.AutoResizeColumns();

        }
        #endregion

        #region Eventos
        /// <summary>
        /// Doble clic en la celda del DataGridView para abrir el directorio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvDirectorios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DgvDirectorios.Columns[e.ColumnIndex].Name == "btnLimpiar" && DgvDirectorios.Rows[e.RowIndex].DataBoundItem is DirectorioALimpiar fila)
            {
                LimpiarDirectorio(fila.Path);
            }
        }


        /// <summary>
        /// Botón para actualizar la lista de directorios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdActualizar_Click(object sender, EventArgs e)
        {
            AnalizarDirectorio();
        }



        #endregion

        #region Funciones

        /// <summary>
        /// Analiza el directorio raíz y obtiene los subdirectorios que tienen más de 2 subdirectorios
        /// </summary>
        private void AnalizarDirectorio()
        {
            string rootPath = TxtRootPath.Text.Trim();

            // Validar si la ruta existe  
            if (Directory.Exists(rootPath))
            {
                ActualizarStatus($"Recorriendo el directorio: {rootPath}");

                List<DirectorioALimpiar> Directorios = [];

                try
                {
                    // Obtener los subdirectorios del directorio raíz  
                    string[] subdirectories = Directory.GetDirectories(rootPath);

                    // Recorrer cada subdirectorio  
                    foreach (string subdirectory in subdirectories)
                    {
                        // Contar los subdirectorios dentro de este subdirectorio  
                        string[] innerDirectories = Directory.GetDirectories(subdirectory);

                        if (innerDirectories.Length >= 2)
                        {
                            ActualizarStatus($"El directorio '{Path.GetFileName(subdirectory)}' contiene {innerDirectories.Length} subdirectorios.");
                            Directorios.Add(new DirectorioALimpiar() { Path = subdirectory, CantDirectorios = innerDirectories.Length });
                        }
                    }


                    // Asignar la fuente de datos
                    DgvDirectorios.DataSource = Directorios.OrderByDescending(c => c.CantDirectorios).ToList<DirectorioALimpiar>();
                    DgvDirectorios.AutoResizeColumns();


                    ActualizarStatus($"Hay {Directorios.Count} Directorios que Corregir");
                }
                catch (UnauthorizedAccessException ex)
                {
                    ActualizarStatus($"Error de acceso: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ActualizarStatus($"Ocurrió un error: {ex.Message}");
                }
            }
            else
            {
                ActualizarStatus("La ruta especificada no existe.");
            }


        }


        /// <summary>
        /// Actualiza el label de información
        /// </summary>
        /// <param name="status"></param>
        void ActualizarStatus(string status)
        {
            LblInfo.Text = status;
            LblInfo.Refresh();
        }


        /// <summary>
        /// Abre el explorador de archivos en la ruta especificada
        /// </summary>
        /// <param name="path"></param>
        private static void LimpiarDirectorio(string path)
        {
            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("La carpeta no existe.");
            }
        }
        #endregion

      
    }
}
