using Art.BussinessLogic;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using Autofac;
using System.Web.Mvc;
namespace Art.Website.Models
{
    public class ArtworkTypesModel
    {
        public ArtworkTypesModel()
        {
            ArtworkTypes = new List<ArtworkTypeModel>();
        }
        public IList<ArtworkTypeModel> ArtworkTypes { get; set; }
    }

    public class ArtworkTypeModel
    {
        public ArtworkTypeModel()
        {
            ArtMaterials = new List<ArtMaterialModel>();
            ArtShapes = new List<ArtShapeModel>();
            ArtTechniques = new List<ArtTechniqueModel>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public IList<ArtMaterialModel> ArtMaterials { get; set; }
        public IList<ArtShapeModel> ArtShapes { get; set; }
        public IList<ArtTechniqueModel> ArtTechniques { get; set; }
    }



    public class ArtworkTypeModelTranslator : TranslatorBase<ArtworkType, ArtworkTypeModel>
    {
        public static readonly ArtworkTypeModelTranslator Instance = new ArtworkTypeModelTranslator();

        public override ArtworkTypeModel Translate(ArtworkType from)
        {
            var to = new ArtworkTypeModel();
            to.Id = from.Id;
            to.Text = from.Name;
            to.ArtMaterials = ArtMaterialModelTranslator.Instance.Translate(from.ArtMaterials);
            to.ArtShapes = ArtShapeModelTranslator.Instance.Translate(from.ArtShapes);
            to.ArtTechniques = ArtTechniqueModelTranslator.Instance.Translate(from.ArtTechniques);
            return to;
        }

        private void RemoveDomainItems(ICollection<BaseEntity> domainItems, ICollection<IIdentityModel> modelItems)
        {
            foreach (var domainItem in domainItems)
            {
                if (modelItems.Any(i => i.Id == domainItem.Id))
                {
                    domainItems.Remove(domainItem);
                }
            }
        }

        public override ArtworkType Translate(ArtworkTypeModel from)
        {
            var logic = DependencyResolver.Current.GetService<IArtworkBussinessLogic>();

            var to = from.Id > 0 ? logic.GetArtworkType(from.Id) : new ArtworkType();

            to.Name = from.Text;

            #region ArtMaterials

            //delete 
            var removingItems = to.ArtMaterials.Where(i => !from.ArtMaterials.Any(p => p.Id == i.Id)).ToList();
            foreach (var domainItem in removingItems)
            {
                to.ArtMaterials.Remove(domainItem);
            }

            //add and update
            foreach (var modelItem in from.ArtMaterials)
            {
                if (modelItem.Id > 0)
                {
                    var material = to.ArtMaterials.Single(i => i.Id == modelItem.Id);
                    material.Name = modelItem.Text;
                }
                else
                {
                    to.ArtMaterials.Add(new ArtMaterial
                    {
                        Name = modelItem.Text,
                    });
                }
            }
            #endregion

            #region ArtShapes
            //delete
            var removingShapes = to.ArtShapes.Where(i => !from.ArtShapes.Any(p => p.Id == i.Id)).ToList();
            foreach (var domainItem in removingShapes)
            {
                to.ArtShapes.Remove(domainItem);
            }

            //add and update
            foreach (var modelItem in from.ArtShapes)
            {
                if (modelItem.Id > 0)
                {
                    var domainItem = to.ArtShapes.Single(i => i.Id == modelItem.Id);
                    domainItem.Name = modelItem.Text;
                }
                else
                {
                    to.ArtShapes.Add(new ArtShape
                    {
                        Name = modelItem.Text,
                    });
                }
            }
            #endregion

            #region ArtTechniques
            //delete 
            var removingTechniques = to.ArtTechniques.Where(i => !from.ArtTechniques.Any(p => p.Id == i.Id)).ToList();
            foreach (var domainItem in removingTechniques)
            {
                to.ArtTechniques.Remove(domainItem);
            }

            //add and update
            foreach (var modelItem in from.ArtTechniques)
            {
                if (modelItem.Id > 0)
                {
                    var domainItem = to.ArtTechniques.Single(i => i.Id == modelItem.Id);
                    domainItem.Name = modelItem.Text;
                }
                else
                {
                    to.ArtTechniques.Add(new ArtTechnique
                    {
                        Name = modelItem.Text,
                    });
                }
            }
            #endregion

            return to;
        }
    }
}