INPUT_FILE=../files/complicated.pdf 
DOCX_FILE=complicated.pdf.docx
rm -rf $DOCX_FILE

source ../setup_tests.sh

python ../../scripts/recreate_database.py --forget-old-data

python ../../conv_storage_server.py --clear-db --server-address $DECLARATOR_CONV_URL --db-json converted_file_storage.json \
	--ocr-input-folder ../pdf.ocr --ocr-output-folder  ../pdf.ocr.out --disable-killing-winword &
conv_server_pid=$!
disown


python ../../scripts/convert_pdf.py $INPUT_FILE --conversion-timeout 180 --output-folder .

kill $conv_server_pid >/dev/null

if [ ! -f $DOCX_FILE ]; then
  echo "cannot get converted file"
  exit  1
fi

filesize=`stat --printf="%s" $DOCX_FILE`
if [ $filesize -ge 15000 ]; then
  echo "the size of the output file must be less than 15000 (from Finereader), winword converts it to a chinese doc"
  exit  1
fi

