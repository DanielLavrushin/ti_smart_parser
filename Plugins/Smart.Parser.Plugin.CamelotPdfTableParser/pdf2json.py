import camelot
import json
import os
import sys
import warnings

def process_pdf(input_path, output_dir=None):
    # Determine output directory
    if output_dir is None:
        output_dir = os.path.dirname(input_path) if os.path.isfile(input_path) else input_path

    # If input is a single file
    if os.path.isfile(input_path) and input_path.lower().endswith(".pdf"):
        process_single_pdf(input_path, output_dir)
    # If input is a directory, process all PDFs in it
    elif os.path.isdir(input_path):
        for filename in os.listdir(input_path):
            if filename.lower().endswith(".pdf"):
                pdf_path = os.path.join(input_path, filename)
                process_single_pdf(pdf_path, output_dir)
    else:
        print(f"Invalid input path: {input_path}")

def process_single_pdf(pdf_path, output_dir):
    is_scan = False
    try:
        print(f"Processing {pdf_path}...")

        # Catch image-based page warnings
        with warnings.catch_warnings(record=True) as w:
            warnings.simplefilter("always")
            tables = camelot.read_pdf(pdf_path, flavor="lattice", split_text=True, pages="all")

            # Check if any warnings indicate image-based pages
            for warning in w:
                if "image-based" in str(warning.message):
                    is_scan = True
                    break

        # Convert all tables to JSON-like structure
        camelot_data = {
            "hasScanDocuments": is_scan,
            "tables": [table.df.to_dict(orient="records") for table in tables]
        }
        
        output_filename = os.path.basename(pdf_path) + ".json"
        output_path = os.path.join(output_dir, output_filename)

        # Save JSON data
        with open(output_path, "w", encoding="utf-8") as f:
            json.dump(camelot_data, f, ensure_ascii=False, indent=4)

        print(f"Extracted tables saved to {output_path}")

    except IndexError:
        print(f"Skipping {pdf_path} due to table parsing error.")

if __name__ == "__main__":
    # Parse command-line arguments
    if len(sys.argv) < 2:
        print("Usage: python pdf2json.py <input_path> [output_dir]")
        sys.exit(1)

    input_path = sys.argv[1]
    output_dir = sys.argv[2] if len(sys.argv) > 2 else None

    process_pdf(input_path, output_dir)
