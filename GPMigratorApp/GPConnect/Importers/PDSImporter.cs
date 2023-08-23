﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using GPConnect.Provider.AcceptanceTests.Data;

namespace GPConnect.Provider.AcceptanceTests.Importers
{
    public static class PDSImporter
    {
        public static List<PDS> LoadCsv(string filename)
        {
            using (var csv = new CsvReader(new StreamReader(filename), CultureInfo.DefaultThreadCurrentCulture))
            {
                csv.Context.RegisterClassMap<PDSMap>();
                return csv.GetRecords<PDS>().ToList();
            }
        }
    }
}
