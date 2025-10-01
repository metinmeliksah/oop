(function () {
	const root = document.documentElement;

	function getStoredTheme() {
		try { return localStorage.getItem('theme') || 'dark'; } catch { return 'dark'; }
	}
	function setStoredTheme(theme) {
		try { localStorage.setItem('theme', theme); } catch {}
	}
	function applyTheme(theme) {
		if (theme === 'light') root.classList.add('light'); else root.classList.remove('light');
	}

	function initThemeToggle() {
		const btn = document.getElementById('theme-toggle');
		const current = getStoredTheme();
		applyTheme(current);
		btn.textContent = current === 'light' ? '🌙' : '☀️';
		btn.addEventListener('click', () => {
			const isLight = root.classList.toggle('light');
			const t = isLight ? 'light' : 'dark';
			setStoredTheme(t);
			btn.textContent = t === 'light' ? '🌙' : '☀️';
		});
	}

	function initMobileMenu() {
		const toggle = document.querySelector('.nav-toggle');
		const menu = document.getElementById('site-menu');
		if (!toggle || !menu) return;
		toggle.addEventListener('click', () => {
			const open = menu.classList.toggle('open');
			toggle.setAttribute('aria-expanded', String(open));
		});
		menu.querySelectorAll('a').forEach(a => a.addEventListener('click', () => {
			menu.classList.remove('open');
			toggle.setAttribute('aria-expanded', 'false');
		}));
	}

	function setActiveNavOnScroll() {
		const sections = ['ana-sayfa','proje','hakkimda','iletisim'].map(id => document.getElementById(id));
		const links = Array.from(document.querySelectorAll('.menu a'));
		const obs = new IntersectionObserver((entries) => {
			entries.forEach(entry => {
				if (entry.isIntersecting) {
					const id = entry.target.id;
					links.forEach(l => l.removeAttribute('aria-current'));
					const active = links.find(l => l.getAttribute('href') === `#${id}`);
					if (active) active.setAttribute('aria-current', 'page');
				}
			});
		}, { rootMargin: '-50% 0px -50% 0px', threshold: 0 });
		sections.forEach(s => s && obs.observe(s));
	}

	function createBadge(text) {
		const span = document.createElement('span');
		span.className = 'badge';
		span.textContent = text;
		return span;
	}

	function createButton(href, label, icon) {
		const a = document.createElement('a');
		a.className = 'button'; a.href = href; a.target = '_blank'; a.rel = 'noopener noreferrer';
		a.innerHTML = icon ? `${icon}<span>${label}</span>` : label;
		return a;
	}

	function renderSocialLinks() {
		if (!window.siteInfo) return;
		const linksWrap = document.getElementById('social-links');
		linksWrap.innerHTML = '';
		const map = window.siteInfo.social || {};
		Object.entries(map).forEach(([key, val]) => {
			if (!val) return;
			const a = document.createElement('a');
			a.href = val; a.target = '_blank'; a.rel = 'noopener noreferrer';
			a.textContent = key;
			linksWrap.appendChild(a);
		});
	}

	function renderHero() {
		if (!window.siteInfo) return;
		document.getElementById('student-name').textContent = window.siteInfo.name || 'Ad Soyad';
		document.getElementById('footer-name').textContent = window.siteInfo.name || 'Öğrenci';
		document.getElementById('student-bio').textContent = window.siteInfo.bio || '';
		const img = document.getElementById('profile-image');
		if (window.siteInfo.profileImage) img.src = window.siteInfo.profileImage;
		document.getElementById('year').textContent = String(new Date().getFullYear());
		const brand = document.querySelector('.brand');
		if (brand) brand.textContent = window.siteInfo.name || 'Öğrenci';
		renderSocialLinks();
	}
	function normalizeImagePath(src) {
		if (!src) return src;
		if (src.startsWith('http')) return src;
		if (src.startsWith('/')) return src.replace(/^\/+/, '');
		return src;
	}


	function renderContact() {
		if (!window.siteInfo) return;
		const ul = document.getElementById('contact-list');
		ul.innerHTML = '';
		const items = window.siteInfo.contact || [];
		items.forEach(({ label, value, href }) => {
			const li = document.createElement('li');
			if (href) {
				const a = document.createElement('a'); a.href = href; a.textContent = value || label;
				if (href.startsWith('http')) { a.target = '_blank'; a.rel = 'noopener noreferrer'; }
				li.appendChild(a);
			} else {
				li.textContent = `${label}: ${value}`;
			}
			ul.appendChild(li);
		});
	}

	// removed old thumbnail-based YouTube embed to simplify implementation

	function renderProject() {
		const p = window.project || {};
		const titleEl = document.getElementById('project-title');
		const descEl = document.getElementById('project-desc');
		const badgesEl = document.getElementById('project-badges');
		const actionsEl = document.getElementById('project-actions');
		const galleryEl = document.getElementById('project-gallery');
		const videoEl = document.getElementById('project-video');
		const videoSection = document.querySelector('.video-section');

		if (!titleEl || !descEl || !badgesEl || !actionsEl) return;

		titleEl.textContent = p.title || 'Proje';
		const docTitle = document.querySelector('title');
		if (docTitle) {
			const siteName = (window.siteInfo && window.siteInfo.name) ? window.siteInfo.name : '';
			docTitle.textContent = siteName && p.title ? `${siteName} — ${p.title}` : (p.title || siteName || 'Proje');
		}
		descEl.textContent = p.description || '';

		// render gallery
		if (galleryEl) {
			galleryEl.innerHTML = '';
			const images = Array.isArray(p.images) && p.images.length ? p.images : (p.image ? [p.image] : []);
			images.forEach((src, idx) => {
				const item = document.createElement('div');
				item.className = 'gallery-item' + (idx === 0 ? ' active' : '');
				const img = document.createElement('img'); img.src = normalizeImagePath(src); img.alt = `${p.title || 'Proje'} görsel ${idx+1}`; img.loading = 'lazy';
				img.onerror = () => { item.remove(); };
				item.appendChild(img);
				galleryEl.appendChild(item);
			});
			initGalleryCarousel(galleryEl);
		}

		// render video (simple direct iframe) or hide section if missing
		if (videoEl) {
			videoEl.innerHTML = '';
			const hasVideo = Boolean(p.youtubeId && String(p.youtubeId).trim());
			if (videoSection) videoSection.style.display = hasVideo ? '' : 'none';
			if (hasVideo) {
				const frame = document.createElement('div');
				frame.className = 'video-frame';
				const iframe = document.createElement('iframe');
				iframe.loading = 'lazy';
				iframe.allow = 'accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share';
				iframe.referrerPolicy = 'strict-origin-when-cross-origin';
				iframe.src = `https://www.youtube-nocookie.com/embed/${p.youtubeId}`;
				iframe.setAttribute('allowfullscreen', '');
				iframe.title = 'YouTube video player';
				frame.appendChild(iframe);
				videoEl.appendChild(frame);
			}
		}

		badgesEl.innerHTML = '';
		if (Array.isArray(p.tech)) p.tech.forEach(t => badgesEl.appendChild(createBadge(t)));

		actionsEl.innerHTML = '';
		if (p.repo) actionsEl.appendChild(createButton(p.repo, 'Repo', '💻'));
		if (p.download) actionsEl.appendChild(createButton(p.download, 'İndir', '⬇️'));
		// removed demo button
		if (Array.isArray(p.docs)) p.docs.forEach(d => actionsEl.appendChild(createButton(d.href, d.label || 'Döküman', '📄')));
	}

	function initGalleryCarousel(gallery) {
		const items = Array.from(gallery.querySelectorAll('.gallery-item'));
		if (items.length <= 1) return;
		let index = 0;
		const prev = document.querySelector('.gallery-nav.prev');
		const next = document.querySelector('.gallery-nav.next');
		function update(activeIdx) {
			items.forEach((el, i) => el.classList.toggle('active', i === activeIdx));
		}
		prev && prev.addEventListener('click', () => { index = (index - 1 + items.length) % items.length; update(index); });
		next && next.addEventListener('click', () => { index = (index + 1) % items.length; update(index); });
		let timer = setInterval(() => { index = (index + 1) % items.length; update(index); }, 3500);
		gallery.addEventListener('mouseenter', () => clearInterval(timer));
		gallery.addEventListener('mouseleave', () => { timer = setInterval(() => { index = (index + 1) % items.length; update(index); }, 3500); });
	}

	document.addEventListener('DOMContentLoaded', () => {
		initThemeToggle();
		initMobileMenu();
		setActiveNavOnScroll();
		renderHero();
		renderContact();
		renderProject();
	});
})();

