using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;

namespace BusinessCardScan.API
{
    public class BusinessCardRecognizer
    {
        readonly AzureKeyCredential Credential;
        readonly DocumentAnalysisClient Client;
        public BusinessCardRecognizer(IConfiguration configuration)
        {
            Credential = new AzureKeyCredential(configuration["CognitiveServices:apiKey"]);
            Client = new DocumentAnalysisClient(new Uri(configuration["CognitiveServices:endpoint"]), Credential);
        }

        public async Task<BusinessCard> ProcessBusinessCardAsync(Stream card)
        {
            BusinessCard businessCard = new BusinessCard();
            AnalyzeDocumentOperation operation = await Client.StartAnalyzeDocumentAsync("prebuilt-businessCard", card); 
            
            await operation.WaitForCompletionAsync();

            AnalyzeResult result = operation.Value;

            for (int i = 0; i < result.Documents.Count; i++)
            {
                Console.WriteLine($"Document {i}:");

                AnalyzedDocument document = result.Documents[i];

                if (document.Fields.TryGetValue("Locale", out DocumentField? localeField))
                {
                    if (localeField.ValueType == DocumentFieldType.String)
                    {
                        businessCard.Locale = localeField.AsString();
                        Console.WriteLine($"Locale: '{businessCard.Locale}', with confidence {localeField.Confidence}");
                    }
                }

                if (document.Fields.TryGetValue("ContactNames", out DocumentField? contactNamesField))
                {
                    if (contactNamesField.ValueType == DocumentFieldType.List)
                    {
                        foreach (DocumentField itemField in contactNamesField.AsList())
                        {
                            Console.WriteLine("Contact Name:");
                            if (itemField.ValueType == DocumentFieldType.Dictionary)
                            {
                                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.AsDictionary();

                                if (itemFields.TryGetValue("FirstName", out DocumentField? firstNameField))
                                {
                                    if (firstNameField.ValueType == DocumentFieldType.String)
                                    {
                                        businessCard.FirstName = firstNameField.AsString();
                                        Console.WriteLine($"  FirstName: '{businessCard.FirstName}', with confidence {firstNameField.Confidence}");
                                    }
                                }

                                if (itemFields.TryGetValue("LastName", out DocumentField? lastNameField))
                                {
                                    if (lastNameField.ValueType == DocumentFieldType.String)
                                    {
                                        businessCard.LastName = lastNameField.AsString();
                                        Console.WriteLine($"  LastName: '{businessCard.LastName}', with confidence {lastNameField.Confidence}");
                                    }
                                }
                            }
                        }
                    }
                }


                if (document.Fields.TryGetValue("CompanyNames", out DocumentField? companyNamesField))
                {
                    if (companyNamesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.CompanyNames = new List<string>();
                        foreach (DocumentField itemField in companyNamesField.AsList())
                        {
                            if (itemField.ValueType == DocumentFieldType.String)
                            {
                                string companyName = itemField.AsString();
                                businessCard.CompanyNames.Add(companyName);
                                Console.WriteLine($"Company name: '{companyName}', with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }


                if (document.Fields.TryGetValue("Departments", out DocumentField? departmentsField))
                {
                    if (departmentsField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.Departments = new List<string>();
                        foreach (DocumentField itemField in departmentsField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.String)
                            {
                                string departmentName = itemField.AsString();
                                businessCard.Departments.Add(departmentName);
                                Console.WriteLine($"Department name: '{departmentName}', with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }


                if (document.Fields.TryGetValue("JobTitles", out DocumentField? jobTitlesField))
                {
                    if (jobTitlesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.JobTitles = new List<string>();
                        foreach (DocumentField itemField in jobTitlesField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.String)
                            {
                                string jobTitle = itemField.AsString();
                                businessCard.JobTitles.Add(jobTitle);
                                Console.WriteLine($"Job Title: '{jobTitle}', with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }


                if (document.Fields.TryGetValue("Emails", out DocumentField? emailsField))
                {
                    if (emailsField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.Emails = new List<string>();
                        foreach (DocumentField itemField in emailsField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.String)
                            {
                                string email = itemField.AsString();
                                businessCard.Emails.Add(email);
                                Console.WriteLine($"Email: '{email}', with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("Websites", out DocumentField? websitesField))
                {
                    if (websitesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.Websites = new List<string>();
                        foreach (DocumentField itemField in websitesField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.String)
                            {
                                string website = itemField.AsString();
                                businessCard.Websites.Add(website);
                                Console.WriteLine($"Website: '{website}', with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }


                if (document.Fields.TryGetValue("Addresses", out DocumentField? addressesField))
                {
                    if (addressesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.Addresses = new List<string>();
                        foreach (DocumentField itemField in addressesField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.String)
                            {
                                string addrs = itemField.AsString();
                                businessCard.Addresses.Add(addrs);
                                Console.WriteLine($"Address: '{addrs}', with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("MobilePhones", out DocumentField? mobilePhonesField))
                {
                    if (mobilePhonesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.MobilePhones = new List<string>();
                        foreach (DocumentField itemField in mobilePhonesField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.PhoneNumber)
                            {
                                string phoneNumber = itemField.Content;
                                businessCard.MobilePhones.Add(phoneNumber);
                                Console.WriteLine($"Phone Number: '{phoneNumber}'. with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("Faxes", out DocumentField? faxesField))
                {
                    if (faxesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.Faxes = new List<string>();
                        foreach (DocumentField itemField in faxesField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.PhoneNumber)
                            {
                                string faxNumber = itemField.Content;
                                businessCard.Faxes.Add(faxNumber);
                                Console.WriteLine($"Fax Number: '{faxNumber}'. with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }


                if (document.Fields.TryGetValue("WorkPhones", out DocumentField? workPhonesField))
                {
                    if (workPhonesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.WorkPhones = new List<string>();
                        foreach (DocumentField itemField in workPhonesField.AsList())
                        {

                            if (itemField.ValueType == DocumentFieldType.PhoneNumber)
                            {
                                string workPhone = itemField.Content;
                                businessCard.WorkPhones.Add(workPhone);
                                Console.WriteLine($"Work Phone: '{workPhone}'. with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }

                if (document.Fields.TryGetValue("OtherPhones", out DocumentField? otherPhonesField))
                {
                    if (otherPhonesField.ValueType == DocumentFieldType.List)
                    {
                        businessCard.OtherPhones = new List<string>();
                        foreach (DocumentField itemField in otherPhonesField.AsList())
                        {
                            
                            if (itemField.ValueType == DocumentFieldType.PhoneNumber)
                            {
                                string otherPhoneNumber = itemField.Content;
                                businessCard.OtherPhones.Add(otherPhoneNumber);
                                Console.WriteLine($"Other Number: '{otherPhoneNumber}'. with confidence {itemField.Confidence}");

                            }
                        }
                    }
                }

            }

            return businessCard;
        }
    }
}
