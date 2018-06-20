using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA.Data.Models;
using System.Linq;

namespace ModelUnitTest
{
    [TestClass]
    public class Selects
    {
        ModelPA db = new ModelPA();

        [TestMethod]
        public void Select_Brand()
        {
            try
            {
                db.Brand.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_Category()
        {
            try
            {
                db.Category.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_CategoryTranslate()
        {
            try
            {
                db.CategoryTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_Color()
        {
            try
            {
                db.Color.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_ColorTranslate()
        {
            try
            {
                db.ColorTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_Language()
        {
            try
            {
                db.Language.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_LanguageTranslate()
        {
            try
            {
                db.LanguageTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_Product()
        {
            try
            {
                db.Product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_ProductNamePrefix()
        {
            try
            {
                db.ProductNamePrefix.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_ProductNamePrefixTranslate()
        {
            try
            {
                db.ProductNamePrefixTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_ProductProperty()
        {
            try
            {
                db.ProductProperty.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_ProductPropertyValue()
        {
            try
            {
                db.ProductPropertyValue.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_Property()
        {
            try
            {
                db.Property.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }

        [TestMethod]
        public void Select_PropertyGroup()
        {
            try
            {
                db.PropertyGroup.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_PropertyGroupTranslate()
        {
            try
            {
                db.PropertyGroupTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_PropertyTranslate()
        {
            try
            {
                db.PropertyTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_PropertyValue()
        {
            try
            {
                db.PropertyValue.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_PropertyValueTranslate()
        {
            try
            {
                db.PropertyValueTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_PropertyValueType()
        {
            try
            {
                db.PropertyValueType.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ScannedProduct()
        {
            try
            {
                db.ScannedProduct.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_Shop()
        {
            try
            {
                db.Shop.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ShopProduct()
        {
            try
            {
                db.ShopProduct.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ShopTranslate()
        {
            try
            {
                db.ShopTranslate.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewCategory()
        {
            try
            {
                db.ViewCategory.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewColor()
        {
            try
            {
                db.ViewColor.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewLanguage()
        {
            try
            {
                db.ViewLanguage.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewProduct()
        {
            try
            {
                db.ViewProduct.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewProductNamePrefix()
        {
            try
            {
                db.ViewProductNamePrefix.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewProperty()
        {
            try
            {
                db.ViewProperty.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewPropertyGroup()
        {
            try
            {
                db.ViewPropertyGroup.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewPropertyValue()
        {
            try
            {
                db.ViewPropertyValue.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }


        [TestMethod]
        public void Select_ViewShop()
        {
            try
            {
                db.ViewShop.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.InnerException.Message);
            }
        }
    }
}
