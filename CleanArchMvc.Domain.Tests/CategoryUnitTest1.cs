using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Nome da minha categoria");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Negative Id Value")]
        public void CreateCategory_NegativeIdValue_DomainExceptionValidation()
        {
            Action action = () => new Category(-1, "Nome da minha categoria");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Valor do Id é invalido;");
        }

        [Fact(DisplayName = "Create Category Short Name")]
        public void CreateCategory_ShortName_DomainExceptionValidation()
        {
            Action action = () => new Category(1, "No");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short minimum 3 characters;");
        }

        [Fact(DisplayName = "Create Category Missing Name Value")]
        public void CreateCategory_MissingNameValue_DomainExceptionValidation()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required;");
        }

    }
}
