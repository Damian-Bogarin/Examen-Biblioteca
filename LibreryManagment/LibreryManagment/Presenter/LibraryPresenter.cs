using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Models;
using System.Globalization;

namespace LibreryManagment.Presenter
{
    internal class LibraryPresenter
    {
        IlibraryView libraryView;
        List<IPartner> partners;
        List<IBook> books;
        List<Loan> loans;
        public LibraryPresenter(IlibraryView view)
        {
            libraryView = view;
            partners = new List<IPartner>();
            books = new List<IBook>();
            loans = new List<Loan>();
        }
        public void CreateBook()
        {
            try
            {
                string name = libraryView.GetInputName();
                string autor = libraryView.GetInputAutor();
                int code = int.Parse(libraryView.GetInputISBN());
                if (name == String.Empty || autor == String.Empty)
                {
                    throw new Exception();
                }


                IBook book = new Book(name.Trim(), autor.Trim(), code, new List<Copy>());
                books.Add(book);

                libraryView.ShowBooks(name);
                libraryView.ShowResult($"El libro {name} se agrego correctamente");

            }
            catch (Exception ex)
            {
                libraryView.ShowResult("Datos Invalidos");
            }
        }



        public void GetBook()
        {
            try
            {
                string name = libraryView.GetBookSelected();
                string autor = "Autor no encotrado";
                bool stock = false;
                for (int x = 0; x < books.Count; x++)
                {
                    if (books[x].GetName() == name)
                    {
                        autor = books[x].GetAutor();
                        stock = books[x].StockCopy();
                    }
                }


                libraryView.ShowBook(autor, stock);
            }
            catch (Exception ex)
            {
                libraryView.ShowBook("Autor no encontrado", false);
            }


        }

        public void AddCopy()
        {


            try
            {
                string name = libraryView.GetBookSelected();
                string dateInput = libraryView.GetInputDate();
                string location = libraryView.GetInputLocation();
                bool copyFind = false;
                DateTime converted_dateInput;



                if (name == String.Empty || dateInput == String.Empty || location == String.Empty)
                {
                    throw new Exception();
                }
                else if (DateTime.TryParseExact(
                           dateInput, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out converted_dateInput)
                         )
                {
                    

                    for (int x = 0; x < books.Count; x++)
                    {
                        if (books[x].GetName() == name)
                        {
                            copyFind = true;
                            books[x].AddCopy(new Copy(dateInput, location));
                        }
                        
                    }
                    if (copyFind)
                    {
                        libraryView.ShowCopyError(false);
                    }
                    else
                    {
                        throw new Exception();
                    }
                    

                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                libraryView.ShowCopyError(true);
            }
        }


        public void AddPartner()
        {
            string name = libraryView.GetName();
            string lastName = libraryView.GetLastName();
            string dni = libraryView.GetDNI();
            int dniParser;
            bool vip = libraryView.GetVip();
            string result;

            try
            {
                if (name == String.Empty || lastName == String.Empty)
                {
                    throw new Exception();
                }
                dniParser = int.Parse(dni);

                IPartner partner = new Partner(name, lastName, dniParser, vip);
                partners.Add(partner);

                libraryView.ShowAddResult("Socio añadido");
               libraryView.ShowPartners(dni);


            }
            catch (Exception ex)
            {
                result = "Datos Erroneos";
                libraryView.ShowAddResult(result);
            }

        }


        public void SearchPartner()
        {
            try
            {
                string dni = libraryView.GetPartnerSelected();
                string vip = "?";
                string nameComplete = "?";
                string available = "?";
                

                if(dni == String.Empty)
                {
                    throw new Exception();
                }

                int dniParser = int.Parse(dni);
                
         
                for (int x = 0; x < partners.Count; x++)
                {
                    if (partners[x].GetDNI() == dniParser)
                    {   
                       nameComplete = partners[x].GetName() + " " + partners[x].GetLastName();
                       ;
                        if (partners[x].GetVip())
                        {
                            vip = "Si";
                        }
                        else
                        {
                            vip = "No";
                        }
                        if (partners[x].Available())
                        {
                            available = "Si";
                        }
                        else
                        {
                            available = "No";
                        }

                        libraryView.ShowPartnerAtribute(nameComplete, vip, dni, available);
                    }
                }


                
            }
            catch (Exception ex)
            {
                libraryView.ShowPartnerAtribute("?","?","?", "?");
            }
        }


        public void SearchBook()
        {
            
            try
            {
                string name = libraryView.GetBookToGive();
                
                string available = "?";


                if (name == String.Empty)
                {
                    throw new Exception();
                }

                for (int x = 0; x < books.Count; x++)
                {
                    if (books[x].GetName() == name)
                    {
                     
                            available = $"{books[x].GetListCount()}";
                            libraryView.ShowBookAtribute( available);
                        
                      

                        
                    }
                }



            }
            catch (Exception ex)
            {
                libraryView.LoanError("Datos Erroneos");
            }
        }

        public void GenerateLoan()
        {
            try
            {
                IPartner partner = null;
                IBook book = null;
                Copy copy = null;
                string dni = libraryView.GetPartnerSelected();
                string name = libraryView.GetBookToGive();

                if (dni == String.Empty || name == String.Empty)
                {
                throw new Exception();
                }
               

                int dniParser = int.Parse(dni);

                for (int y = 0; y < partners.Count; y++)
                {
                    if (partners[y].GetDNI() == dniParser)
                    {
                          for (int x = 0; x < books.Count; x++)
                          {
                            if (books[x].GetName() == name)
                            {
                                if (books[x].StockCopy() && partners[y].Available())
                                    {
                                     copy = books[x].GetCopy();
                                     
                                     loans.Add(new Loan(books[x], partners[y], "ha retirado"));
                                     partners[y].GiveCopy(copy);
                                    libraryView.LoanError("Prestamo exitoso");
                                    }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                          }
                    }
                }
               



                
                


            }
            catch
            {
                libraryView.LoanError("Error al generar Prestamo");
            }
           
        }


        public void ReturnLoan()
        {
            try
            {
                IPartner partner = null;
                IBook book = null;
                Copy copy = null;
                string dni = libraryView.GetPartnerSelected();
                string name = libraryView.GetBookToGive();

                if (dni == String.Empty || name == String.Empty)
                {
                    throw new Exception();
                }


                int dniParser = int.Parse(dni);

                for (int y = 0; y < partners.Count; y++)
                {
                    if (partners[y].GetDNI() == dniParser)
                    {
                        for (int x = 0; x < books.Count; x++)
                        {
                            if (books[x].GetName() == name)
                            {
                                
                                    copy = partners[y].ReturnCopy();

                                loans.Add(new Loan(books[x], partners[y], "ha devuelto"));
                                books[x].AddCopy(copy);
                                    libraryView.LoanError("Ejemplar Devuelto");
                                
                            }
                        }
                    }
                }








            }
            catch(Exception e)
            {
                libraryView.LoanError("Ejemplar devuelto Error");
            }
        }

        public void ShowLoan()
        {
            string result = "";
            foreach (var elemt in loans)
            {
                result += $"El socio {elemt.GetNameOfPartner()} {elemt.GetAccion()} el ejemplar del libro: {elemt.GetNameOfCopy()} el dia {elemt.GetDate()} \n";
            }
            libraryView.LoanCharge(result);
        }
    }


}
