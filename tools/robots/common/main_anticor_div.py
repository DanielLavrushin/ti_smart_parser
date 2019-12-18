import sys
from find_link import  click_first_link_and_get_url
from office_list import write_offices

def check_anticorr_link_text(href, text):
    text = text.strip().lower()
    if text.startswith(u'противодействие'):
        return text.find("коррупц") != -1
    return False

def find_anticorruption_div(offices):
    for office_info in offices:
        url = office_info['url']
        sys.stderr.write(url + "\n")
        click_first_link_and_get_url(office_info, 'anticorruption_div', url,  check_anticorr_link_text, True)

    write_offices(offices)
