﻿CREATE UNIQUE NONCLUSTERED  INDEX IX_Name ON ArtworkType (Name) WHERE IsDeleted = 0
GO