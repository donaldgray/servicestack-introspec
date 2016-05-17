﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this 
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

namespace ServiceStack.Documentation.Tests.Validators
{
    using Documentation.Settings;
    using Documentation.Validators;
    using FluentValidation.TestHelper;
    using Xunit;

    public class ApiSpecConfigValidatorTests
    {
        private readonly ApiSpecConfigValidator validator = new ApiSpecConfigValidator();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Description_IsMandatory(string description)
        {
            validator.ShouldHaveValidationErrorFor(v => v.Description, new ApiSpecConfig { Description = description });
        }

        [Fact]
        public void Contact_IsMandatory()
        {
            validator.ShouldHaveValidationErrorFor(v => v.Contact, new ApiSpecConfig { Contact = null });
        }

        [Fact]
        public void Contact_HasValidator()
        {
            validator.ShouldHaveChildValidator(v => v.Contact, typeof(ApiContactValidator));
        }
    }
}
