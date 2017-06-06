CREATE TABLE public.users
(
    Id uuid NOT NULL,
	Username character varying(256) NOT NULL,
	PasswordHash character varying(256),
	SecurityStamp character varying(256),
	Email character varying(256) DEFAULT NULL::character varying,
	EmailConfirmed boolean NOT NULL DEFAULT false,
    PRIMARY KEY (Id)
)
WITH (
    OIDS = FALSE
);

ALTER TABLE public.users
    OWNER to postgres;