﻿// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this 
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

namespace ServiceStack.IntroSpec.Models
{
    public class ApiSecurity
    {
        public bool IsProtected { get; set; }
        public Permissions Roles { get; set; }
        public Permissions Permissions { get; set; }
    }
}