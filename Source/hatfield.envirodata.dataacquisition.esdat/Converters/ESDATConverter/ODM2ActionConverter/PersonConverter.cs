﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class PersonConverter : ODM2ActionConverter
    {
        public PersonConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Person Convert(Affiliation affiliation)
        {
            Person person = new Person();

            person.PersonFirstName = string.Empty;
            person.PersonLastName = string.Empty;
            person.Affiliations.Add(affiliation);

            return person;
        }
    }
}