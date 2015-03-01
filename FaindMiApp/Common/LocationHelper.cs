namespace FaindMiApp.Common
{
    using System;
    using Windows.Devices.Geolocation;

    /// <summary>
    /// Helper para obtener la ubicación actual.
    /// </summary>
    public class LocationHelper
    {
        #region Campos

        /// <summary>
        /// Da acceso a la ubicación actual.
        /// </summary>
        private Geolocator gl;

        #endregion

        #region Manejadores

        /// <summary>
        /// Manejador para indicar cuando se obtine la posición.
        /// </summary>
        public EventHandler<PosicionEventHandler> PosicionObtenidaCompleted;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor vacío que inicializa el objeto GeoLocator para poder detectar la ubicación actual.
        /// </summary>
        public LocationHelper()
        {
            gl = new Geolocator();
            gl.DesiredAccuracyInMeters = 1;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Método asíncrono que obtiene la posición actual.
        /// </summary>
        public async void ObtenerPosicion()
        {
            try
            {
                Geoposition gp = await gl.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromSeconds(1),
                    timeout: TimeSpan.FromSeconds(10));

                if (this.PosicionObtenidaCompleted != null)
                {
                    PosicionObtenidaCompleted(this, new PosicionEventHandler(gp));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
