using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FaindMiApp.Common
{
    /// <summary>
    /// Clase que sirver para convertir un booleano a tipo Visibility, necesario para mostrar en base a un booleano un UIElement.
    /// </summary>
    public static class BooleanToVisibilityConverter : IValueConverter
    {
        #region Métodos Públicos

        /// <summary>
        /// Se encarga de convertir el tipo especificado a uno de visibility.
        /// </summary>
        /// <param name="value">Valor a convertir.</param>
        /// <param name="targetType">Tipo de objeto el cual se desea devolver.</param>
        /// <param name="parameter">Parámetro.???</param>
        /// <param name="culture">Cultura desde donde se llama el método.</param>
        /// <returns>El objeto con el formato requerido.</returns>
        public static object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Método encargado de regresar al objeto original.
        /// </summary>
        /// <param name="value">Valor a convertir.</param>
        /// <param name="targetType">Tipo de objeto el cual se desea devolver.</param>
        /// <param name="parameter">Parámetro.???</param>
        /// <param name="culture">Cultura desde donde se llama el método.</param>
        /// <returns>El objeto con el formato requerido.</returns>e"></param>
        /// <returns></returns>
        public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visiblity = (Visibility)value;

            return visiblity == Visibility.Visible;
        }

        #endregion
    }
}
