using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Name of Product", "Description of Product", 9.99m, 99, "Image of product");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionValidation()
        {
            Action action = () => new Product(-1, "Name of Product", "Description of Product", 9.99m, 99, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Valor do Id é invalido;");
        }


        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "", "Description of Product", 9.99m, 99, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required;");
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Name of Product", "", 9.99m, 99, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description. Description is required;");
        }



        [Fact]
        public void CreateProduct_ShortName_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Na", "Description of Product", 9.99m, 99, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short minimum 3 characters;");
        }       

        [Fact]
        public void CreateProduct_ShortDescription_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Name of Product", "Desc", 9.99m, 99, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short minimum 5 characters;");
        }

        [Fact]
        public void CreateProduct_InvalidPrice_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Name of Product", "Description of Product", -1, 99, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value;");
        }

        [Fact]
        public void CreateProduct_InvalidStock_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Name of Product", "Description of Product", 9.99m, -1, "Image of product");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value;");
        }

        [Fact]
        public void CreateProduct_LongImage_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Name of Product", "Description of Product", 9.99m, 9, "Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - Image of product - ");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too long maximum 250 characters;");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainExceptionValidation()
        {
            Action action = () => new Product(1, "Name of Product", "Description of Product", 9.99m, 9, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Name of Product", "Description of Product", 9.99m, 9, null);
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}
