# Generated by Django 3.1.1 on 2020-10-17 14:16

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('declarations', '0004_auto_20201017_1415'),
    ]

    operations = [
        migrations.AlterField(
            model_name='person',
            name='id',
            field=models.IntegerField(primary_key=True, serialize=False),
        ),
        migrations.AlterField(
            model_name='section',
            name='id',
            field=models.IntegerField(primary_key=True, serialize=False),
        ),
    ]
