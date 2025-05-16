namespace CantNuggerPorCarpeta.Modelos
{
    public class DirectorioALimpiar
    {

        /// <summary>
        /// Ruta del directorio
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad de subdirectorios
        /// </summary>
        public int CantDirectorios { get; set; }

        /// <summary>
        /// Tamaño total de los subdirectorios (en bytes) 
        /// </summary>
        public long DirectoriesSize { get; set; }



        /// <summary>
        /// Tamaño total de los subdirectorios (en MB)
        /// </summary>

        public string DirectoriesSizeMB => $"{DirectoriesSize / (1024.0 * 1024):F2} MB";
    }
}
