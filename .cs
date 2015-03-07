List<Employee> list = new List<Employee>();

            for (int i = 6; i < 11; i++)
            {
                Employee emp = new Employee();
                emp.ID = i.ToString();
                emp.Name = "Thien" + i;
                emp.PhoneNumber = "012345678";
                list.Add(emp);
            }



            string jsonString = JsonConvert.SerializeObject(list);
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync("data.txt", CreationCollisionOption.OpenIfExists);
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                
                    using (DataWriter writer = new DataWriter(stream))
                    {
                        writer.WriteString(jsonString);
                        await writer.StoreAsync();
                        MessageDialog msg = new MessageDialog("Write Success!", "Result");
                        await msg.ShowAsync();
                        ResetFile();
                    }
                
            }
