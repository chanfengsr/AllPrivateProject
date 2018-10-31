from flask import render_template, session, redirect, url_for, current_app
from .. import db
from ..models import User
# from ..email import send_email
from . import main
from .forms import NameForm
import flask.ext.wtf


@main.route('/', methods = ['GET', 'POST'])
def indexX ():
    form = NameForm()
    if form.validate_on_submit():
        user = User.query.filter_by(username = form.strUserName.data).first()
        if user is None:
            user = User(username = form.strUserName.data)
            db.session.add(user)
            session['known'] = False
        else:
            session['known'] = True

        session['name'] = form.strUserName.data
        return redirect(url_for('main.indexX'))

    return render_template("index.html",
                           form = form, name = session.get("name"),
                           known = session.get('known', False))
