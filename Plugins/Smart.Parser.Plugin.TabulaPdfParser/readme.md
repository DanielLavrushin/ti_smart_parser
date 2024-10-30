# Camelot Setup Guide

This guide walks through the process of setting up Camelot in Python for extracting tables from PDF files, handling dependencies, and post-processing to ensure empty cells are converted to null values in JSON output.

1. Install Camelot and Required Libraries
   Camelot relies on several libraries, including `pdfminer.six` and, optionally, `opencv-python` and `ghostscript` for enhanced functionality.

Run the following command to install Camelot with its core dependencies:

```bash
pip install camelot-py[cv]
```

This installs camelot-py along with opencv-python (cv2) for processing PDFs in lattice mode.

2. Install Additional Dependencies
   Camelot may require additional tools and libraries, depending on the type of PDFs you’re processing.

### Ghostscript (required for lattice mode):

Download `Ghostscript` from the official Ghostscript website.

> https://www.ghostscript.com/releases/gsdnld.html

Install it and add the Ghostscript bin folder to your system PATH (e.g., C:\Program Files\gs\gs9.56.1\bin).
To verify the installation, open a new Command Prompt and run:

```bash
gswin64c -version
```

Camelot’s lattice mode also needs the `ghostscript` Python package.

```bash
pip install ghostscript
```
