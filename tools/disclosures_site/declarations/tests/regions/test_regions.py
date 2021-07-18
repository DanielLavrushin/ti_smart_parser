from common.russian_regions import TRussianRegions


from django.test import TestCase
from operator import itemgetter

class RegionsTestCase(TestCase):


    def test_regions_nominative(self):
        regions = TRussianRegions()
        self.assertEqual(63, regions.get_region_in_nominative("Москва").id)
        self.assertEqual(9, regions.get_region_in_nominative("Кабардино-Балкария").id)
        self.assertEqual(17, regions.get_region_in_nominative("Северная Осетия").id)
        self.assertEqual(109, regions.get_region_in_nominative("Крым").id)
        self.assertEqual(109, regions.get_region_in_nominative("Республика Крым").id)
        self.assertEqual(1, regions.get_region_in_nominative("санкт-петербург").id)

    def test_regions_nominative_and_dative(self):
        regions = TRussianRegions()
        self.assertEqual(63, regions.get_region_in_nominative_and_dative("по г.Москве").id)
        self.assertEqual(63, regions.get_region_in_nominative_and_dative("по  г.Москве").id)
        self.assertEqual(9, regions.get_region_in_nominative_and_dative("по кабардино-балкарской республике").id)
        self.assertEqual(17, regions.get_region_in_nominative_and_dative("по северной осетии").id)
        self.assertEqual(109, regions.get_region_in_nominative_and_dative("по республике Крым").id)
        self.assertEqual(1, regions.get_region_in_nominative_and_dative("по санкт-петербургу").id)
        self.assertEqual(None, regions.get_region_in_nominative_and_dative("по московской области   мусор"))

    def test_regions_all_forms(self):
        def r(s):
            d = regions.get_region_all_forms(s)
            return d
        regions = TRussianRegions()
        self.assertEqual(63, r("мэр Москвы Собянин"))
        self.assertEqual(1, r("Московский район Санкт-Петербурга"))
        self.assertEqual(28, r("Никита Рязанский из Красноярского края"))
        self.assertEqual(28, r("представитель Москвы в Красноярском крае")) #longest match
        self.assertEqual(28, r("Межрегиональное управление № 042 ФМБА (Красноярский край, г. Зеленогорск"))
