SET IDENTITY_INSERT [dbo].[Form] ON
INSERT INTO [dbo].[Form] ([Id], [eFormTypeId], [Name], [Code], [Description], [Schema], [IsActive], [Version], [CreatedOn], [CreatedBy], [User], [TS]) VALUES (1, 2, N'form_1', N'Person', N'desc_1 - extra long desc goes here...', N'{
    "title": "Person",
    "type": "object",

    "properties": {
        "name": {
            "type": "string",
            "description": "First and Last name",
            "minLength": 4,
            "default": "Boris Momtchev"
        },

        "age": {
            "type": "integer",
            "default": 41,
            "minimum": 18,
            "maximum": 99
        },

        "favorite_color": {
            "type": "string",
            "format": "color",
            "title": "favorite color",
            "default": "#ffa500"
        },

        "gender": {
            "type": "string",
            "enum": [
            "male",
            "female"
            ]
        }
    }
}', 1, N'1.00', N'2016-08-24 16:24:41', N'anonymous', N'anonymous', N'2016-08-24 16:28:41')
INSERT INTO [dbo].[Form] ([Id], [eFormTypeId], [Name], [Code], [Description], [Schema], [IsActive], [Version], [CreatedOn], [CreatedBy], [User], [TS]) VALUES (2, 1, N'form_2', N'Address', N'desc_2 - extra long desc goes here...', N'{
    "title": "Address",
    "type": "object",

    "properties": {
        "street": {
            "type": "string",
            "description": "Street number and name",
            "default": "100 Main St"
        },

        "zip": {
            "type": "integer",
            "default": 41000
        },
        
        "apt": {
            "type": "string"
        },        

        "state": {
            "type": "string",
            "enum": [
            "MN",
            "NY"
            ]
        }
    }
}', 1, N'1.00', N'2016-08-24 16:24:41', N'anonymous', N'anonymous', N'2016-08-24 16:28:51')
SET IDENTITY_INSERT [dbo].[Form] OFF