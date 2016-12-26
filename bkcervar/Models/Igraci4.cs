
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UIOMatic.Attributes;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace bkcervar.Models
{
    [UIOMatic("igraci4", "Igraci4", "Igrac4", FolderIcon = "icon-users", ItemIcon = "icon-user")]
    [TableName("Igraci4")]
    public class Igrac4
    {
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [UIOMaticField(Name = "Red_broj", Description = "Unesite redni broj")]
        public string Red_broj { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [UIOMaticField(Name = "Ime", Description = "Unesite ime i prezime")]
        public string ImePrezime { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [UIOMaticField(Name = "Registarski broj", Description = "Unesite registarski broj")]
        public string Reg_broj { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [UIOMaticField(Name = "Adresa", Description = "Unesite adresu igraca")]
        public string Adresa { get; set; }


        [UIOMaticField(Name = "Picture", Description = "Select a picture", View = UIOMatic.Constants.FieldEditors.File)]
        public string Picture { get; set; }

        public override string ToString()
        {
            return ImePrezime;
        }


    }
}