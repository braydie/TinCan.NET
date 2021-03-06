﻿/*
    Copyright 2014 Rustici Software
    Modifications copyright (C) 2018 Neal Daniel

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/
using System;
using Newtonsoft.Json.Linq;
using TinCan.Json;

namespace TinCan
{
    public class Verb : JsonModel
    {
        public Uri Id { get; set; }
        public LanguageMap Display { get; set; }

        public Verb() {}

        public Verb(StringOfJson json): this(json.ToJObject()) {}

        public Verb(JObject jobj)
        {
            if (jobj["id"] != null)
            {
                Id = new Uri(jobj.Value<string>("id"));
            }
            if (jobj["display"] != null)
            {
                Display = (LanguageMap)jobj.Value<JObject>("display");
            }
        }

        public Verb(Uri uri)
        {
            Id = uri;
        }

        public Verb(string str)
        {
            Id = new Uri (str);
        }

        public override JObject ToJObject(TCAPIVersion version) {
            var result = new JObject();
            if (Id != null)
            {
                result.Add("id", Id.ToString());
            }

            if (Display != null && ! Display.IsEmpty())
            {
                result.Add("display", Display.ToJObject(version));
            }

            return result;
        }

        public static explicit operator Verb(JObject jobj)
        {
            return new Verb(jobj);
        }
    }
}
