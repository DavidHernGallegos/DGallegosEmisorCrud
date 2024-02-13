using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Emisor
    {
       public static  Dictionary<string,object> GetAll()
        {
           ML.Emisor emisor = new ML.Emisor();
           Dictionary<string,object> diccionario = new Dictionary<string, object> { {"Emisor ", emisor },{"Resultado", false },{"Mensaje", "" } };

            try
            {
                using (DL.LGallegosEmisonEntities context = new DL.LGallegosEmisonEntities())
                {
                    var query = context.GetAllEmisor().ToList();
                    if (query != null)
                    {
                        emisor.Emisores = new List<object>();
                        foreach( var objEmisor in query )
                        {
                            ML.Emisor e = new ML.Emisor();
                            e.IdEmisor = objEmisor.IdEmisor;
                            e.RFC= objEmisor.RFC;
                            e.FechaInicioOperacion = objEmisor.FechaInicioOperacion.Value;
                            e.Capital = objEmisor.Capital.Value;
                            emisor.Emisores.Add(e);
                        }

                        diccionario["Resultado"] = true;
                        diccionario["Mensaje"] = "Se han cargado los datos";
                        diccionario["Emisor"] = emisor;
                    }
                    else
                    {
                        diccionario["Mensaje"] = "N se han cargado los datos";
                    }
                }
            }
            catch (Exception e)
            {
                diccionario["Mensaje"] = "N se han cargado los datos" + e;
            }

            return diccionario;
        }


        public static Dictionary<string, object> GetById(int idEmisor)
        {
            ML.Emisor emisor = new ML.Emisor();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Emisor ", emisor }, { "Resultado", false }, { "Mensaje", "" } };

            try
            {
                using (DL.LGallegosEmisonEntities context = new DL.LGallegosEmisonEntities())
                {
                    var query = context.GetByIdEmisor(idEmisor).SingleOrDefault();
                    if (query != null)
                    {

                        emisor.IdEmisor = query.IdEmisor;
                        emisor.RFC = query.RFC;
                        emisor.FechaInicioOperacion = query.FechaInicioOperacion.Value;
                        emisor.Capital = query.Capital.Value;
                   
                        diccionario["Resultado"] = true;
                        diccionario["Mensaje"] = "Se han cargado los datos";
                        diccionario["Emisor"] = emisor;
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se han cargado los datos";
                    }
                }
            }
            catch (Exception e)
            {
                diccionario["Mensaje"] = "No se han cargado los datos" + e;
            }

            return diccionario;
        }

        public static Dictionary<string, object> Add(ML.Emisor emisor)
        {
           
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", "" } };

            try
            {
                using (DL.LGallegosEmisonEntities context = new DL.LGallegosEmisonEntities())
                {
                    var query = context.AddEmisor(emisor.RFC,emisor.FechaInicioOperacion,emisor.Capital);
                    if (query > 0)
                    {

                       
                        diccionario["Mensaje"] = "Se han guardado los datos";
                        diccionario["Resultado"] = true;
              
                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se han cargado los datos";
                    }
                }
            }
            catch (Exception e)
            {
                diccionario["Mensaje"] = "No se han cargado los datos" + e;
            }

            return diccionario;
        }

        public static Dictionary<string, object> Update(ML.Emisor emisor)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", "" } };

            try
            {
                using (DL.LGallegosEmisonEntities context = new DL.LGallegosEmisonEntities())
                {
                    var query = context.UpdateEmisor(emisor.IdEmisor,emisor.RFC, emisor.FechaInicioOperacion, emisor.Capital);
                    if (query > 0)
                    {


                        diccionario["Mensaje"] = "Se han Actualizado los datos";
                        diccionario["Resultado"] = true;

                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se han actualizado los datos";
                    }
                }
            }
            catch (Exception e)
            {
                diccionario["Mensaje"] = "No se han actualizado los datos" + e;
            }

            return diccionario;
        }

        public static Dictionary<string, object> Delete(int idEmisor)
        {

            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Resultado", false }, { "Mensaje", "" } };

            try
            {
                using (DL.LGallegosEmisonEntities context = new DL.LGallegosEmisonEntities())
                {
                    var query = context.DeleteEmisor(idEmisor);
                    if (query > 0)
                    {


                        diccionario["Mensaje"] = "Se han borrado los datos";
                        diccionario["Resultado"] = true;

                    }
                    else
                    {
                        diccionario["Mensaje"] = "No se han borrado los datos";
                    }
                }
            }
            catch (Exception e)
            {
                diccionario["Mensaje"] = "No se han borrado los datos" + e;
            }

            return diccionario;
        }


    }



}
