CREATE TABLE public."Messages" (
	"Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	"Date" timestamptz NOT NULL,
	"From" text NOT NULL,
	"Body" text NOT NULL,
	CONSTRAINT "PK_Messages" PRIMARY KEY ("Id")
);