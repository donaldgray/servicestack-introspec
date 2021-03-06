﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this 
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

namespace ServiceStack.IntroSpec.Tests.Enrichers
{
    using System;
    using FluentAssertions;
    using Host;
    using IntroSpec.Enrichers;
    using IntroSpec.Models;
    using IntroSpec.Settings;
    using Xunit;

    public class FallbackEnricherTests
    {
        private readonly FallbackEnricher fallback = new FallbackEnricher();

        private Operation operation => new Operation();
        private Type type => typeof(AllAttributes);

        [Fact]
        public void GetTitle_ReturnsNull() => fallback.GetTitle(type).Should().BeNull();

        [Fact]
        public void GetDescription_ReturnsNull() => fallback.GetDescription(type).Should().BeNull();

        [Fact]
        public void GetRelativePath_ReturnsNull() => fallback.GetRelativePaths(operation, "GET").Should().BeNull();

        [Fact]
        public void GetNotes_ReturnsFallbackNotes_FromSettings()
        {
            const string notes = "this is a good api";
            using (DocumenterSettings.With(fallbackNotes: notes))
                fallback.GetNotes(type).Should().Be(notes);
        }

        [Fact]
        public void GetStatusCodes_ReturnsStatusCodes_FromSettings()
        {
            var codes = new[] { (StatusCode)200, (StatusCode)409 };
            using (DocumenterSettings.With(defaultStatusCodes: codes))
                fallback.GetStatusCodes(operation, "GET").Should().BeEquivalentTo(codes);
        }

        [Fact]
        public void GetCategory_ReturnsFallbackNotes_FromSettings()
        {
            const string category = "danger";
            using (DocumenterSettings.With(fallbackCategory: category))
                fallback.GetCategory(operation).Should().Be(category);
        }

        [Fact]
        public void GetTags_ReturnTags_FromSettings()
        {
            var tags = new[] { "Tag1", "Tag2" };
            using (DocumenterSettings.With(defaultTags: tags))
                fallback.GetTags(operation).Should().BeEquivalentTo(tags);
        }

        [Fact]
        public void GetTags_ReturnsContentTypes_FromSettings()
        {
            var contentTypes = new[] { "test/jsv", "text/csv" };
            using (DocumenterSettings.With(defaultContentTypes: contentTypes))
                fallback.GetContentTypes(operation, "GET").Should().BeEquivalentTo(contentTypes);
        }

        [Fact]
        public void GetNotes_ReturnsFallbackRouteNotes_FromSettings()
        {
            const string notes = "this is a good route";
            using (DocumenterSettings.With(fallbackRouteNotes: notes))
                fallback.GetNotes(operation, "GET").Should().Be(notes);
        }
    }
}
