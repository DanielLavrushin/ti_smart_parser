import camelot
import json

# Read tables from the PDF file
tables = camelot.read_pdf("file_101344.pdf", flavor="lattice", split_text=True)

# Convert the first table to a list of dictionaries (JSON-like)
table_data = tables[0].df.to_dict(orient="records")

with open("output_with_nulls.json", "w", encoding="utf-8") as f:
    json.dump(table_data, f, ensure_ascii=False, indent=4)

print("Table with empty cells as nulls saved to output_with_nulls.json")
