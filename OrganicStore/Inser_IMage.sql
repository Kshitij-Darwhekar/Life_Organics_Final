CREATE TABLE Test(
 product_id int,
 pic image,
)

INSERT INTO TEST(pic) SELECT BulkColumn FROM Openrowset(Bulk 'C:\Users\KshitijDarwhekar\Pictures\Orange.jpg' , Single_blob  ) as img ;