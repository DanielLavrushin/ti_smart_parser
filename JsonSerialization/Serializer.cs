﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

using TI.Declarator.ParserCommon;

namespace TI.Declarator.JsonSerialization
{
    public static class DeclarationSerializer
    {
        private static CultureInfo DefaultCulture = CultureInfo.InvariantCulture;
        private static CultureInfo RussianCulture = CultureInfo.CreateSpecificCulture("ru-ru");

        private static readonly string SchemaSource = "import-schema-dicts.json";
        private static JSchema Schema;

        static DeclarationSerializer()
        {
            Schema = JSchema.Parse(File.ReadAllText(SchemaSource));
        }

        public static string Serialize(IEnumerable<PublicServant> servants)
        {
            var jServants = new JArray();
            foreach (var serv in servants)
            {
                jServants.Add(Serialize(serv));
            }

            if (Validate(jServants))
            {
                return jServants.ToString();
            }
            else
            {
                throw new Exception("Could not validate JSON output");
            }
        }

        private static JObject Serialize(PublicServant servant)
        {
            var jServ = new JObject(
                GetPersonalData(servant),
                GetInstitutiondata(servant),
                GetYear(servant),
                GetIncomes(servant),
                GetRealEstateProperties(servant));

            return jServ;
        }

        private static JProperty GetPersonalData(PublicServant servant)
        {
            return new JProperty("person", new JObject(
                                              new JProperty("name", servant.Name),
                                              new JProperty("name_raw", servant.Name),
                                              new JProperty("family_name", servant.FamilyName),
                                              new JProperty("first_name", servant.GivenName),
                                              new JProperty("patronymic_name", servant.Patronymic),
                                              new JProperty("role", new JArray(servant.Occupation))));
        }

        private static JProperty GetInstitutiondata(PublicServant servant)
        {
            return new JProperty("office", new JObject(
                                            // TODO how to get department name?
                                            new JProperty("name", "Министерство странных походок")));
        }

        private static JProperty GetYear(PublicServant servant)
        {
            // TODO extract year from file name or document title
            return new JProperty("year", 3000);
        }

        private static JProperty GetIncomes(PublicServant servant)
        {
            var jIncomes = new JArray();
            jIncomes.Add(new JObject(
                // TODO should income size really be an integer
                new JProperty("size", (int?)servant.DeclaredYearlyIncome),
                new JProperty("relative", null)));

            foreach (var rel in servant.Relatives)
            {
                jIncomes.Add(new JObject(
                new JProperty("size", (int?)rel.DeclaredYearlyIncome),
                new JProperty("relative", GetRelationshipName(rel.RelationType))));
            }

            var res = new JProperty("incomes", jIncomes);
            return res;            
        }

        private static JProperty GetRealEstateProperties(PublicServant servant)
        {
            var jRealEstate = new JArray();

            foreach (var prop in servant.RealEstateProperties)
            {
                jRealEstate.Add(new JObject(
                    new JProperty("name", prop.Name),
                    new JProperty("type", GetPropertyType(prop)),
                    // TODO should property area really be an integer
                    new JProperty("square", (int)prop.Area),
                    new JProperty("country", GetCountry(prop)),
                    new JProperty("region", null),
                    new JProperty("own_type", GetOwnershipType(prop)),
                    new JProperty("share_type", GetShareType(prop)),
                    new JProperty("share_amount", GetOwnershipShare(prop)),
                    new JProperty("relative", null)));
            }

            foreach (var rel in servant.Relatives)
            {
                foreach (var prop in rel.RealEstateProperties)
                {
                    jRealEstate.Add(new JObject(
                        new JProperty("name", prop.Name),
                        new JProperty("type", GetPropertyType(prop)),
                        // TODO should property area really be an integer
                        new JProperty("square", (int)prop.Area),
                        new JProperty("country", GetCountry(prop)),
                        new JProperty("region", null),
                        new JProperty("own_type", GetOwnershipType(prop)),
                        new JProperty("share_type", GetShareType(prop)),
                        new JProperty("share_amount", GetOwnershipShare(prop)),
                        new JProperty("relative", GetRelationshipName(rel.RelationType))));
                }
            }

            var res = new JProperty("real_estates", jRealEstate);
            return res;
        }

        private static bool Validate(JArray jServants)
        {
            IList<string> comments = new List<string>();
            bool res = jServants.IsValid(Schema, out comments);
            return res;
        }

        private static string GetRelationshipName(RelationType rt)
        {
            switch (rt)
            {
                case RelationType.FemaleSpouse:
                case RelationType.MaleSpouse: return "Супруг(а)";
                case RelationType.Child: return "Ребенок";
                default: throw new ArgumentOutOfRangeException("rt", $"Unsupported relationship type: {rt.ToString()}");
            }
        }

        private static string GetPropertyType(RealEstateProperty prop)
        {
            switch(prop.PropertyType)
            {
                case RealEstateType.Apartment: return "Квартира";
                case RealEstateType.Garage: return "Гараж";
                case RealEstateType.Dacha: return "Дача";
                case RealEstateType.HabitableHouse: return "Жилой дом";
                case RealEstateType.PlotOfLand: return "Земельный участок";
                case RealEstateType.ParkingSpace:
                case RealEstateType.Other: return "Иное";
                default: throw new ArgumentOutOfRangeException("prop.PropertyType", $"Unsupported real estate type: {prop.PropertyType.ToString()}");
            }
        }

        private static string GetCountry(RealEstateProperty prop)
        {
            switch (prop.Country)
            {
                case Country.Undefined: return null;
                case Country.Russia: return "Россия";
                default: throw new ArgumentOutOfRangeException("prop.Country", $"Invalid country name: {prop.Country.ToString()}");
            }
        }

        private static string GetOwnershipType(RealEstateProperty prop)
        {
            if (prop.OwnershipType == OwnershipType.NotAnOwner)
            {
                return "В пользовании";
            }
            else
            {
                return "В собственности";
            }
        }

        private static string GetShareType(RealEstateProperty prop)
        {
            switch(prop.OwnershipType)
            {
                case OwnershipType.Coop: return "Совместная собственность";
                case OwnershipType.Individual: return "Индивидуальная";
                // This is by design; non-ownership is still considered an individual ownership
                case OwnershipType.NotAnOwner: return "Индивидуальная";
                case OwnershipType.Shared: return "Долевая собственность";
                default: throw new ArgumentOutOfRangeException("prop.OwnershipType", $"Unsupported ownership type: {prop.OwnershipType.ToString()}");
            }
        }

        private static decimal? GetOwnershipShare(RealEstateProperty prop)
        {
            string ownedShare = prop.OwnedShare;
            if (prop.OwnershipType == OwnershipType.Shared)
            {
                if (ownedShare.IsNullOrWhiteSpace())
                {
                    return null;
                }
                else if (ownedShare == "½")
                {
                    return 0.5M;
                }
                else if (ownedShare.Contains("/"))
                {
                    var parts = ownedShare.Split(new char[] { '/', ' ' });
                    var num = Decimal.Parse(parts[0]);
                    var den = Decimal.Parse(parts[1]);
                    // Убираем ненужные нули в хвосте и, при необходимости, десятичный разделитель
                    return (num / den);
                }
                else
                {
                    decimal factor = 1.0M;
                    if (ownedShare.EndsWith("%")) { factor = 0.01M; }
                    string shareStr = ownedShare.TrimEnd('%');
                    return Decimal.Parse(shareStr, RussianCulture) * factor;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
