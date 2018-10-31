from werkzeug.security import generate_password_hash, check_password_hash
from app.models import User


u = User()
u.password='cf'
print(u.password_hash)
print(u.verify_password("cf"))

print('')
u2 = User()
u2.password='cf'
print(u2.password_hash)
print(u2.verify_password("cf"))